//---------------------------------------------------------------------------
//
// Description: Host and the server part of XmlWCFAnnotationStore
//
// History:  
//  10/2006 - Svetlana Simova created 
//
//---------------------------------------------------------------------------

using System;
using System.IO;
using System.ServiceModel;
using System.Collections.Generic;
using System.Windows.Annotations;
using System.Windows.Annotations.Storage;
using System.Xml;
using System.Xml.Serialization;
using System.ServiceModel.Description;

/// <summary>
/// Hosting application for XmlWCFStoreService
/// </summary>
internal class XmlWCFStoreHost
{
    static void Main(string[] args)
    {
        string host = "localhost";
        if ((args != null) && (args.Length > 0))
        {
            host = args[0];
        }

        ServiceHost myServiceHost = new ServiceHost(typeof(XmlWCFStore.XmlWCFStoreService), new Uri[] { new Uri("http://" + host + ":8080/XmlWCFStore.XmlWCFStoreService") });
        try
        {
            //we need dual binding to allow callbacks to the client
            WSDualHttpBinding binding = new WSDualHttpBinding(WSDualHttpSecurityMode.None);
            myServiceHost.AddServiceEndpoint(typeof(XmlWCFStore.IXmlWCFStoreService), binding, "");
            ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
            smb.HttpGetEnabled = true;
            myServiceHost.Description.Behaviors.Add(smb);
            myServiceHost.Open();
            Console.WriteLine("Press any key to quit");
            Console.ReadKey();
            myServiceHost.Close();

        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }

}

namespace XmlWCFStore
{

    /// <summary>
    /// The server part of the XmlWCFAnnotationStore. Holds all the annotations in an XmlStreamStores.
    /// The clients opens stores
    /// by names, for each name there is ona XmlStreamStore and 
    /// notifications for annotations changes are propagated to all clients, who opened the same store. 
    /// </summary>
    [ServiceBehavior(IncludeExceptionDetailInFaults = true, ConcurrencyMode = ConcurrencyMode.Multiple, InstanceContextMode = InstanceContextMode.Single)]
    public class XmlWCFStoreService : IXmlWCFStoreService
    {
        #region Public Methods

        /// <summary>
        /// Open a store for the client. If a XmlStreamStore with this name exists
        /// registers the client with the existing store data
        /// </summary>
        /// <param name="name">store name</param>
        public void OpenStore(string name)
        {
            if (name == null)
            {
                throw new XmlWCFStoreException("undefined store name");
            }
            lock (_syncRoot)
            {
                StoreData storeData = FindStore(name);
                if (storeData == null)
                {
                    storeData = new StoreData(name);
                    _stores.Add(storeData);

                    //register for store events
                    storeData.Store.StoreContentChanged += new StoreContentChangedEventHandler(OnStoreContentChanged);
                    storeData.Store.AnchorChanged += new AnnotationResourceChangedEventHandler(OnAnnotationAnchorChanged);
                    storeData.Store.CargoChanged += new AnnotationResourceChangedEventHandler(OnAnnotationCargoChanged);
                    storeData.Store.AuthorChanged += new AnnotationAuthorChangedEventHandler(OnAnnotationAuthorChanged);
                }
                _registeredClients.Add(OperationContext.Current.GetCallbackChannel<IXmlWCFStore>(), storeData);
            }
        }

        /// <summary>
        /// Close a store. The client is unregistered from this store. If there are no more 
        /// registered clients the XmlStreamStore is closed.
        /// </summary>
        public void CloseStore()
        {
            lock (_syncRoot)
            {
                IXmlWCFStore callback = OperationContext.Current.GetCallbackChannel<IXmlWCFStore>();
                StoreData storeData = null;
                //find client callback
                if (_registeredClients.ContainsKey(callback))
                {
                    storeData = _registeredClients[callback];
                    _registeredClients.Remove(callback);
                }
                if (!_registeredClients.ContainsValue(storeData))
                {
                    //unregister for store events
                    storeData.Store.StoreContentChanged -= new StoreContentChangedEventHandler(OnStoreContentChanged);
                    storeData.Store.AnchorChanged -= new AnnotationResourceChangedEventHandler(OnAnnotationAnchorChanged);
                    storeData.Store.CargoChanged -= new AnnotationResourceChangedEventHandler(OnAnnotationCargoChanged);
                    storeData.Store.AuthorChanged -= new AnnotationAuthorChangedEventHandler(OnAnnotationAuthorChanged);
                    storeData.Stream.Close();
                    storeData.Store.Dispose();
                    _stores.Remove(storeData);
                }
            }
        }

        /// <summary>
        /// Add a new annotation to this store.  The new annotation's Id
        /// is set to a new value.
        /// </summary>
        /// <param name="newAnnotation">the annotation to be added to the store</param>
        /// <exception cref="ArgumentNullException">newAnnotation is null</exception>
        /// <exception cref="ArgumentException">newAnnotation already exists in this store, as determined by its Id</exception>
        /// <exception cref="ObjectDisposedException">if object has been disposed</exception>
        public void AddAnnotation(byte[] newAnnotation)
        {
            if (newAnnotation == null)
            {
                throw new ArgumentNullException("newAnnotation");
            }
            lock (_syncRoot)
            {
                IList<Annotation> annotations = Helper.Deserialize(newAnnotation);
                if (annotations.Count != 1)
                {
                    throw new XmlWCFStoreException("unexpected nummber of annotations to add");
                }

                Annotation annotation = annotations[0];
                ClientStore.AddAnnotation(annotation);
            }
        }

        /// <summary>
        ///     Delete the specified annotation.
        /// </summary>
        /// <param name="annotationId">the Id of the annotation to be deleted</param>
        /// <returns>the annotation that was deleted</returns>
        /// <exception cref="ObjectDisposedException">if object has been disposed</exception>
        public byte[] DeleteAnnotation(Guid annotationId)
        {
            byte[] data = null;
            lock (_syncRoot)
            {
                Annotation res = ClientStore.DeleteAnnotation(annotationId);
                if (res != null)
                {
                    data = Helper.Serialize(res);
                }
            }
            return data;
        }

        /// <summary>
        ///     Queries the AnnotationStore for annotations that have an anchor
        ///     that contains a locator that begins with the locator parts
        ///     in anchorLocator. 
        /// </summary>
        /// <param name="anchorLocator">the locator we are looking for</param>
        /// <returns>
        ///     A list of annotations that have locators in their anchors
        ///    starting with the same locator parts list as of the input locator
        ///    Can return an empty list, but never null.
        /// </returns>
        /// <exception cref="ObjectDisposedException">if object has been disposed</exception>
        public byte[] GetAnnotationsByLocator(byte[] locator)
        {
            if (locator == null)
            {
                throw new ArgumentNullException("locator");
            }
            lock (_syncRoot)
            {
                ContentLocator anchorLocator = Helper.DeserializeLocator(locator);
                IList<Annotation> res = ClientStore.GetAnnotations(anchorLocator);
                return Helper.Serialize(res);
            }
        }


        /// <summary>
        /// Returns a list of all annotations in the store
        /// </summary>
        /// <exception cref="ObjectDisposedException">if object has been disposed</exception>
        /// <returns>annotations list. Can return an empty list, but never null.</returns>
        public byte[] GetAnnotations()
        {
            lock (_syncRoot)
            {
                IList<Annotation> res = ClientStore.GetAnnotations();
                return Helper.Serialize(res);
            }
        }

        /// <summary>
        /// Finds annotation by Id
        /// </summary>
        /// <param name="annotationId"></param>
        /// <exception cref="ObjectDisposedException">if object has been disposed</exception>
        /// <returns>The annotation. Null if the annotation does not exists</returns>
        public byte[] GetAnnotation(Guid annotationId)
        {
            lock (_syncRoot)
            {
                Annotation res = ClientStore.GetAnnotation(annotationId);
                if (res != null)
                {
                    return Helper.Serialize(res);
                }
            }
            return null;
        }


        /// <summary>
        ///     Causes any buffered data to be written to the underlying storage 
        ///     mechanism.  Gets called after each operation if 
        ///     AutoFlush is set to true.
        /// </summary>
        /// <remarks>
        ///     Applications that have an explicit save model may choose to call
        ///     this method directly when appropriate.  Applications that have an
        ///     implied save model, see AutoFlush.
        /// </remarks>
        /// <exception cref="ObjectDisposedException">if object has been disposed</exception>
        /// <seealso cref="AutoFlush"/>
        public void Flush()
        {
            lock (_syncRoot)
            {
                ClientStore.Flush();
            }
        }

        /// <summary>
        /// The client part uses this to notify the server when there are changes 
        /// in the annotation author
        /// </summary>
        /// <param name="annotationId">ID of changed annotation</param>
        /// <param name="action">type of the change - add, remove, modify</param>
        /// <param name="author">the new author</param>
        public void ProcessAuthor(Guid annotationId, int action, string author)
        {
            lock (_syncRoot)
            {
                Annotation ann = ClientStore.GetAnnotation(annotationId);
                //it is possible that the annotation has been deleted meanwhile - do nothing in this case
                if (ann != null)
                {
                    Helper.ProcessAuthor(ann, action, author);
                }
            }
        }

        /// <summary>
        /// The client part uses this to notify the server when there are changes 
        /// in the annotation anchor
        /// </summary>
        /// <param name="annotationId">ID of changed annotation</param>
        /// <param name="action">type of the change - add, remove, modify</param>
        /// <param name="resource">the new resource</param>
        public void ProcessAnchor(Guid annotationId, int action, byte[] resource)
        {
            lock (_syncRoot)
            {
                Annotation ann = ClientStore.GetAnnotation(annotationId);
                //it is possible that the annotation has been deleted meanwhile - do nothing in this case
                if (ann != null)
                {
                    Helper.ProcessResource(ann.Anchors, action, resource);
                }
            }
        }

        /// <summary>
        /// The client part uses this to notify the server when there are changes 
        /// in the annotation cargo
        /// </summary>
        /// <param name="annotationId">ID of changed annotation</param>
        /// <param name="action">type of the change - add, remove, modify</param>
        /// <param name="resource">the new resource</param>
        public void ProcessCargo(Guid annotationId, int action, byte[] resource)
        {
            lock (_syncRoot)
            {
                Annotation ann = ClientStore.GetAnnotation(annotationId);
                //it is possible that the annotation has been deleted meanwhile - do nothing in this case
                if (ann != null)
                {
                    Helper.ProcessResource(ann.Cargos, action, resource);
                }
            }
        }

        /// <summary>
        /// Get current AutoFlush mode
        /// </summary>
        /// <returns>current autoFlush mode</returns>
        public bool GetAutoFlush()
        {
            lock (_syncRoot)
            {
                return ClientStore.AutoFlush;
            }
        }

        /// <summary>
        /// Sets current AutoFlush mode
        /// </summary>
        /// <param name="mode">new AutoFlush mode</param>
        public void SetAutoFlush(bool mode)
        {
            lock (_syncRoot)
            {
                ClientStore.AutoFlush = mode;
            }
        }

        #endregion Public Methods

        #region Private Methods

        /// <summary>
        /// Finds a store by name
        /// </summary>
        /// <param name="name">store name</param>
        /// <returns>StoreData or null</returns>
        private StoreData FindStore(string name)
        {
            foreach (StoreData store in _stores)
            {
                if (store.Name.Equals(name))
                {
                    return store;
                }
            }
            return null;
        }

        /// <summary>
        /// Listens to StoreContentChanged event. Propagates the event to
        /// all clients, registered with this store
        /// </summary>
        /// <param name="sender">not used</param>
        /// <param name="e">data about changed content</param>
        private void OnStoreContentChanged(object sender, StoreContentChangedEventArgs e)
        {
            byte[] annotation = Helper.Serialize(e.Annotation);
            lock (_syncRoot)
            {
                foreach (IXmlWCFStore client in _registeredClients.Keys)
                {
                    if (_registeredClients[client].Store == sender)
                    {
                        client.OnServerStoreContentChanged(annotation, Helper.ConvertStoreContentActionToInt(e.Action));
                    }
                }
            }
        }

        /// <summary>
        /// Listens to AnnotationAuthorChanged event. Propagates the event to
        /// all clients, registered with this store
        /// </summary>
        /// <param name="sender">not used</param>
        /// <param name="e">data about changed annotation and author</param>
        private void OnAnnotationAuthorChanged(object sender, AnnotationAuthorChangedEventArgs e)
        {
            lock (_syncRoot)
            {
                foreach (IXmlWCFStore client in _registeredClients.Keys)
                {
                    if (_registeredClients[client].Store == sender)
                    {
                        client.OnServerAnnotationAuthorChanged(e.Annotation.Id, Helper.ConvertActionToInt(e.Action), (string)e.Author);
                    }
                }
            }
        }

        /// <summary>
        /// Listens to AnnotationAnchorChanged event. Propagates the event to
        /// all clients, registered with this store
        /// </summary>
        /// <param name="sender">not used</param>
        /// <param name="e">data about changed annotation and anchor</param>
        private void OnAnnotationAnchorChanged(object sender, AnnotationResourceChangedEventArgs e)
        {
            byte[] byteResource = Helper.Serialize(e.Resource);
            lock (_syncRoot)
            {
                foreach (IXmlWCFStore client in _registeredClients.Keys)
                {
                    if (_registeredClients[client].Store == sender)
                    {
                        client.OnServerAnnotationAnchorChanged(e.Annotation.Id, e.Resource.Id, Helper.ConvertActionToInt(e.Action), byteResource);
                    }
                }
            }
        }

        /// <summary>
        /// Listens to AnnotationCargoChanged event. Propagates the event to
        /// all clients, registered with this store
        /// </summary>
        /// <param name="sender">not used</param>
        /// <param name="e">data about changed annotation and cargo</param>
        private void OnAnnotationCargoChanged(object sender, AnnotationResourceChangedEventArgs e)
        {
            byte[] byteResource = Helper.Serialize(e.Resource);
            lock (_syncRoot)
            {
                foreach (IXmlWCFStore client in _registeredClients.Keys)
                {
                    if (_registeredClients[client].Store == sender)
                    {
                        client.OnServerAnnotationCargoChanged(e.Annotation.Id, e.Resource.Id, Helper.ConvertActionToInt(e.Action), byteResource);
                    }
                }
            }
        }

        #endregion Private Methods

        #region Private Properties

        /// <summary>
        /// Gets the XmlStreamStore associated with currently
        /// calling client
        /// </summary>
        private AnnotationStore ClientStore
        {
            get
            {
                IXmlWCFStore callback = OperationContext.Current.GetCallbackChannel<IXmlWCFStore>();
                if (_registeredClients.ContainsKey(callback))
                {
                    return _registeredClients[callback].Store;
                }
                else
                {
                    throw new XmlWCFStoreException("A store is not opened for this client");
                }
            }
        }

        #endregion Private Properties

        #region Private classes

        /// <summary>
        /// Holds data about one XmlStreamStore
        /// </summary>
        private class StoreData
        {
            XmlStreamStore _store;
            Stream _stream;
            string _name;
            public StoreData(string name)
            {
                _stream = new FileStream(name, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                _store = new XmlStreamStore(_stream);
                _name = name;
            }
            public Stream Stream { get { return _stream; } }
            public XmlStreamStore Store { get { return _store; } }
            public string Name { get { return _name; } }
        }

        #endregion Private classes

        #region Private Data
        
        //registered clients and their XmlStreamStore data
        private Dictionary<IXmlWCFStore, StoreData> _registeredClients = new Dictionary<IXmlWCFStore, StoreData>();
        //list of all opened XmlStreamStores
        private List<StoreData> _stores = new List<StoreData>();
        //object, used for access synchronization
        private object _syncRoot = new Object();

        #endregion Private Data

    }
}


