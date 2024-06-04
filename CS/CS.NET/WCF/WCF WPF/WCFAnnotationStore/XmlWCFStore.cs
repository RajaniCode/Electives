//---------------------------------------------------------------------------
//
// Description: The client part of WCF AnnotationStore
//
// History:  
//  10/2006 - Svetlana Simova created 
//
//---------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.Windows.Annotations;
using System.Windows.Annotations.Storage;
using System.ServiceModel;
using System.IO;
using System.Threading;
using System.Windows.Threading;

namespace XmlWCFStore
{
    /// <summary>
    /// This is the client part of the WCF AnnotationStore. Many clients can access the same store on the server
    /// which makes possible sharing of annotations between users. This implementation allows 
    /// editing of the same StickyNote from different clients which allows even exchanging messages in real time. 
    /// One client can be used by only one AnnotationService because changes to the annotations, made by other clients are 
    /// posted for asynchronous processing on the AnnotationService Dispatcher thread. 
    /// The modifications from the user on the same machine are processed synchronously, but those coming from the server
    /// as a notification for modifications made by another client, are processed asynchronously. 
    /// As a result it is possible in some race condition situations to have client and server out of sync.
    /// In order to avoid this it is recomended to add some restrictions about who can modify what - 
    /// for example only the author of an annotation can modify it, the others have read only access.
    /// Such restrictions are not implemented in this sample.
    /// </summary>
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Reentrant), CallbackBehavior(ConcurrencyMode = ConcurrencyMode.Reentrant, UseSynchronizationContext = false)]
    public class XmlWCFStore : AnnotationStore, IXmlWCFStore
    {
        /// <summary>
        /// Store ctor
        /// </summary>
        /// <param name="server">StoreService server name</param>
        /// <param name="name">name of the file to store the data</param>
        /// <param name="dispatcher">the dispatcher of the element where the AnnotationService is attached.
        /// This is needed for posting information about changes made by other clients. If the dispatcher 
        /// is null messages will be processed synchronously.</param>
        public XmlWCFStore(string server, string name, Dispatcher dispatcher)
        {

            if (server == null)
            {
                throw new ArgumentNullException("server");
            }

            if (name == null)
            {
                throw new ArgumentNullException("name");
            }

            _dispatcher = dispatcher;

            DuplexChannelFactory<IXmlWCFStoreService> cf = new DuplexChannelFactory<IXmlWCFStoreService>(typeof(XmlWCFStore), new WSDualHttpBinding(WSDualHttpSecurityMode.None));
            _client = (IXmlWCFStoreService)cf.CreateChannel(new InstanceContext(this), new EndpointAddress("http://" + server + ":8080/XmlWCFStore.XmlWCFStoreService"));
            _client.OpenStore(name);
        }

        #region Public Methods

        /// <summary>
        ///     Add a new annotation to this store.  The new annotation's Id
        ///     is set to a new value.
        /// </summary>
        /// <param name="newAnnotation">the annotation to be added to the store</param>
        /// <exception cref="ArgumentNullException">newAnnotation is null</exception>
        /// <exception cref="ArgumentException">newAnnotation already exists in this store, as determined by its Id</exception>
        /// <exception cref="ObjectDisposedException">if object has been disposed</exception>
        public override void AddAnnotation(Annotation newAnnotation)
        {
            //add this annotation to changed by user list
            _changedFromClientStoreContent.Add(newAnnotation.Id);
            bool added = false;
            try
            {
                //add the annotation to the server store
                _client.AddAnnotation(Helper.Serialize(newAnnotation));
                added = true;
                //fire synchronous event
                base.OnStoreContentChanged(new StoreContentChangedEventArgs(StoreContentAction.Added, newAnnotation));
            }
            finally
            {
                //remove the annotation from the changed list
                _changedFromClientStoreContent.Remove(newAnnotation.Id);
            }

            if (added)
            {
                //add the annotation to cached and monitored list
                AddCachedAnnotation(newAnnotation);
            }
        }

        /// <summary>
        ///     Delete the specified annotation.
        /// </summary>
        /// <param name="annotationId">the Id of the annotation to be deleted</param>
        /// <returns>the annotation that was deleted</returns>
        /// <exception cref="ObjectDisposedException">if object has been disposed</exception>
        public override Annotation DeleteAnnotation(Guid annotationId)
        {
            byte[] data = null;
            _changedFromClientStoreContent.Add(annotationId);
            Annotation cachedAnnotation = null;
            try
            {
                data = _client.DeleteAnnotation(annotationId);

                //if we have this annotation in the cache we should use the same instance
                cachedAnnotation = FindCachedAnnotation(annotationId);
                if (cachedAnnotation != null)
                {
                    DeleteCachedAnnotation(cachedAnnotation);
                }
                else if (data != null)
                {
                    cachedAnnotation = Helper.Deserialize(data)[0];
                }

                if (cachedAnnotation != null)
                {
                    base.OnStoreContentChanged(new StoreContentChangedEventArgs(StoreContentAction.Deleted, cachedAnnotation));
                }
            }
            finally
            {
                _changedFromClientStoreContent.Remove(annotationId);
            }


            return cachedAnnotation;
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
        public override IList<Annotation> GetAnnotations(ContentLocator anchorLocator)
        {
            byte[] res = _client.GetAnnotationsByLocator(Helper.Serialize(anchorLocator));
            IList<Annotation> annotations = Helper.Deserialize(res);
            //if we already have instances of those annotations - return the ones we have.
            // Add the new ones to the cache
            UpdateAnnotationList(annotations);
            return annotations;
        }

        /// <summary>
        /// Returns a list of all annotations in the store
        /// </summary>
        /// <exception cref="ObjectDisposedException">if object has been disposed</exception>
        /// <returns>annotations list. Can return an empty list, but never null.</returns>
        public override IList<Annotation> GetAnnotations()
        {
            byte[] res = _client.GetAnnotations();
            IList<Annotation> annotations = Helper.Deserialize(res);
            UpdateAnnotationList(annotations);
            return annotations;
        }

        /// <summary>
        /// Finds annotation by Id
        /// </summary>
        /// <param name="annotationId"></param>
        /// <exception cref="ObjectDisposedException">if object has been disposed</exception>
        /// <returns>The annotation. Null if the annotation does not exists</returns>
        public override Annotation GetAnnotation(Guid annotationId)
        {
            Annotation ann1 = Helper.Deserialize(_client.GetAnnotation(annotationId))[0];
            Annotation ann2 = FindCachedAnnotation(ann1.Id);
            if (ann2 == null)
            {
                AddCachedAnnotation(ann1);
                ann2 = ann1;
            }
            return ann2;
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
        public override void Flush()
        {
            _client.Flush();
        }

        #endregion Public Methods

        #region Protected Methods

        /// <summary>
        /// Disposes any managed and unmanaged resources used by this
        /// store.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            if (disposing)
            {
                _client.CloseStore();
                ((IClientChannel)_client).Close();
            }
        }

        #endregion Protected Methods

        #region Public Properties

        /// <summary>
        ///     When set to true an implementation should call Flush()
        ///     as a side-effect after each operation.
        /// </summary>
        /// <value>
        ///     true if the implementation is set to call Flush() after 
        ///     each operation; false otherwise
        /// </value>
        public override bool AutoFlush
        {
            get
            {
                return _client.GetAutoFlush();
            }
            set
            {
                _client.SetAutoFlush(value);
            }
        }

        #endregion Public Properties

        #region IXmlWCFStoreServiceCallback implementation

        /// <summary>
        /// Called when an Annotation is added or removed from the server
        /// </summary>
        /// <param name="annotation">the added or removed annotation</param>
        /// <param name="action">0 - added, 1- removed</param>
        public void OnServerStoreContentChanged(byte[] annotation, int action)
        {
            IList<Annotation> res = Helper.Deserialize(annotation);
            if (res == null || res.Count != 1)
            {
                throw new Exception("unexpected Store Content data");
            }
            Annotation sAnnotation = res[0];
            //if we are adding or deleting this annotation at the moment
            // the corresponding function will fire the event
            if (!_changedFromClientStoreContent.Contains(sAnnotation.Id))
            {
                StoreContentChangedEventArgs e = new StoreContentChangedEventArgs(Helper.ConvertIntToStoreContentAction(action), sAnnotation);
                if (_dispatcher != null)
                {
                    _dispatcher.BeginInvoke(DispatcherPriority.Background, new DispatcherOperationCallback(ProcessStoreContentCallback), e);
                }
            }
        }

        /// <summary>
        /// Process AnnotationAuthorChanged event from the server store. If the event is triggered
        /// as a result of modification on this client we do nothing because the event is already fired.
        /// </summary>
        /// <param name="annotationId">annotation Id</param>
        /// <param name="action">action - Added, Removed, Modified</param>
        /// <param name="author">author name</param>
        public void OnServerAnnotationAuthorChanged(Guid annotationId, int action, string author)
        {
            //if we are modifying this annotation at the moment
            // the corresponding function will fire the event
            if (!_changedFromClientAnnotations.Contains(annotationId))
            {
                Annotation sAnnotation = FindCachedAnnotation(annotationId);
                //we care only about changes in cached annotations because these are 
                //the annotations loaded on this client by the momet.
                if (sAnnotation != null)
                {
                    AnnotationAction sAction = Helper.ConvertAnnotationAction(action);
                    AnnotationAuthorChangedEventArgs e = new AnnotationAuthorChangedEventArgs(sAnnotation, sAction, author);
                    if (_dispatcher != null)
                    {
                        _dispatcher.BeginInvoke(DispatcherPriority.Background, new DispatcherOperationCallback(ProcessAuthorCallback), e);
                    }
                    else
                    {
                        ProcessAuthorCallback(e);
                    }
                }
            }
        }

        /// <summary>
        /// Process AnnotationAnchorChanged event from the server store. If the event is triggered
        /// as a result of modification on this client we do nothing because the event is already fired.
        /// </summary>
        /// <param name="annotationId">annotation Id</param>
        /// <param name="action">action - Added, Removed, Modified</param>
        /// <param name="resource">serialized resource</param>
        public void OnServerAnnotationAnchorChanged(Guid annotationId, Guid resourceId, int action, byte[] resource)
        {
            OnServerAnnotationResourceChanged(annotationId, resourceId, ResourceType.Anchor, action, resource);
        }

        /// <summary>
        /// Process AnnotationCargoChanged event from the server store. If the event is triggered
        /// as a result of modification on this client we do nothing because the event is already fired.
        /// </summary>
        /// <param name="annotationId">annotation Id</param>
        /// <param name="action">action - Added, Removed, Modified</param>
        /// <param name="resource">serialized resource</param>
        public void OnServerAnnotationCargoChanged(Guid annotationId, Guid resourceId, int action, byte[] resource)
        {
            OnServerAnnotationResourceChanged(annotationId, resourceId, ResourceType.Cargo, action, resource);
        }

        #endregion IXmlWCFStoreServiceCallback implementation

        #region Private Methods

        #region Annotations changed by client handlers

        /// <summary>
        /// Listens to AnnotationAuthorChanged events from cached annotations on this client.
        /// Calls server so the changes are reflected to the store and the other clients. 
        /// </summary>
        /// <param name="sender">not used</param>
        /// <param name="args">data about changed annotation and author</param>
        private void OnClientAnnotationAuthorChanged(object sender, AnnotationAuthorChangedEventArgs args)
        {
            //If this annotation is in any of the "changed" lists - it is already processed
            if (_changedFromClientAnnotations.Contains(args.Annotation.Id) || IsChangedFromStoreAnnotation(args.Annotation.Id))
                return;

            //if this is a new one - it is changed by the user - notify the server
            _changedFromClientAnnotations.Add(args.Annotation.Id);
            _client.ProcessAuthor(args.Annotation.Id, Helper.ConvertActionToInt(args.Action), (string)args.Author);
            //call synchronously all the listeners on the client
            base.OnAuthorChanged(args);
            _changedFromClientAnnotations.Remove(args.Annotation.Id);
        }

        /// <summary>
        /// Listens to AnnotationAnchorChanged events from cached annotations on this client
        /// Calls server so the changes are reflected to the store and the other clients. 
        /// </summary>
        /// <param name="sender">not used</param>
        /// <param name="args">data about changed annotation and anchor</param>
        private void OnClientAnnotationAnchorChanged(object sender, AnnotationResourceChangedEventArgs args)
        {
            //If this annotation is in any of the "changed" lists - it is already processed
            if (_changedFromClientAnnotations.Contains(args.Annotation.Id) || IsChangedFromStoreAnnotation(args.Annotation.Id))
                return;
            //if this is a new one - it is changed by the user - notify the server
            _changedFromClientAnnotations.Add(args.Annotation.Id);
            _client.ProcessAnchor(args.Annotation.Id, Helper.ConvertActionToInt(args.Action), Helper.Serialize(args.Resource));
            //call synchronously all the listeners on the client
            base.OnAnchorChanged(args);
            _changedFromClientAnnotations.Remove(args.Annotation.Id);
        }

        /// <summary>
        /// Listens to AnnotationAuthorChanged events from cached annotations on this client
        /// Calls server so the changes are reflected to the store and the other clients. 
        /// </summary>
        /// <param name="sender">not used</param>
        /// <param name="args">data about changed annotation and cargo</param>
        private void OnClientAnnotationCargoChanged(object sender, AnnotationResourceChangedEventArgs args)
        {
            //If this annotation is in any of the "changed" lists - it is already processed
            if (_changedFromClientAnnotations.Contains(args.Annotation.Id) || IsChangedFromStoreAnnotation(args.Annotation.Id))
                return;
            //if this is a new one - it is changed by the user - notify the server
            _changedFromClientAnnotations.Add(args.Annotation.Id);
            _client.ProcessCargo(args.Annotation.Id, Helper.ConvertActionToInt(args.Action), Helper.Serialize(args.Resource));
            //call synchronously all the listeners on the client
            base.OnCargoChanged(args);
            _changedFromClientAnnotations.Remove(args.Annotation.Id);
        }

        #endregion Annotations changed by user handlers

        #region Callbacks for Dispatcher items

        /// <summary>
        /// Called by the Dispatcher to process changes in the store made by other clients
        /// </summary>
        /// <param name="arg">StoreContentChangedEventArgs</param>
        /// <returns>always null</returns>
        private object ProcessStoreContentCallback(object arg)
        {
            StoreContentChangedEventArgs resArgs = arg as StoreContentChangedEventArgs;
            if (resArgs != null)
            {
                AddChangedFromStoreAnnotation(resArgs.Annotation.Id);
                Annotation cachedAnnotation = FindCachedAnnotation(resArgs.Annotation.Id);
                if (resArgs.Action == StoreContentAction.Added)
                { //this is a new annotation - add it to the cache
                    if (cachedAnnotation != null)
                    {
                        throw new Exception("adding existing annotation");
                    }
                    AddCachedAnnotation(resArgs.Annotation);
                }
                else
                {
                    if (cachedAnnotation != null)
                    {
                        //remove the annotation from the cache
                        DeleteCachedAnnotation(resArgs.Annotation);
                    }
                }
                base.OnStoreContentChanged(resArgs);
                RemoveChangedFromStoreAnnotation(resArgs.Annotation.Id);
            }
            return null;
        }

        /// <summary>
        /// Called by the Dispatcher to process changes in a cached annotation made by other clients.
        /// </summary>
        /// <param name="arg">AnnotationResourceChangedEventArgs</param>
        /// <returns>always null</returns>
        private object ProcessCargoCallback(object arg)
        {
            AnnotationResourceChangedEventArgs resArgs = arg as AnnotationResourceChangedEventArgs;
            if (resArgs != null)
            {
                AddChangedFromStoreAnnotation(resArgs.Annotation.Id);
                Helper.ProcessResource(resArgs.Annotation.Cargos, resArgs.Action, resArgs.Resource);
                base.OnCargoChanged(resArgs);
                RemoveChangedFromStoreAnnotation(resArgs.Annotation.Id);
            }
            return null;
        }

        /// <summary>
        /// Called by the Dispatcher to process changes in a cached annotation made by other clients.
        /// </summary>
        /// <param name="arg">AnnotationResourceChangedEventArgs</param>
        /// <returns>always null</returns>
        private object ProcessAnchorCallback(object arg)
        {
            AnnotationResourceChangedEventArgs resArgs = arg as AnnotationResourceChangedEventArgs;
            if (resArgs != null)
            {
                AddChangedFromStoreAnnotation(resArgs.Annotation.Id);
                Helper.ProcessResource(resArgs.Annotation.Anchors, resArgs.Action, resArgs.Resource);
                base.OnAnchorChanged(resArgs);
                RemoveChangedFromStoreAnnotation(resArgs.Annotation.Id);
            }
            return null;
        }

        /// <summary>
        /// Called by the Dispatcher to process changes in a cached annotation made by other clients.
        /// </summary>
        /// <param name="arg">AnnotationAuthorChangedEventArgs</param>
        /// <returns>always null</returns>
        private object ProcessAuthorCallback(object arg)
        {
            AnnotationAuthorChangedEventArgs resArgs = arg as AnnotationAuthorChangedEventArgs;
            if (resArgs != null)
            {
                AddChangedFromStoreAnnotation(resArgs.Annotation.Id);
                Helper.ProcessAuthor(resArgs.Annotation, Helper.ConvertActionToInt(resArgs.Action), resArgs.Author as string);
                base.OnAuthorChanged(resArgs);
                RemoveChangedFromStoreAnnotation(resArgs.Annotation.Id);
            }
            return null;
        }

        #endregion Callbacks for Dispatcher items

        #region Helper functions

        /// <summary>
        /// Finds an annotation in the list of chached annotations 
        /// </summary>
        /// <param name="annotationId">the Id if searched annotation</param>
        /// <returns>cached annotation or null</returns>
        private Annotation FindCachedAnnotation(Guid annotationId)
        {
            Annotation ann = null;
            lock (_cachedAnnotations)
            {
                if (_cachedAnnotations.ContainsKey(annotationId))
                {
                    ann = _cachedAnnotations[annotationId];
                }
            }
            return ann;
        }

        /// <summary>
        /// Adds an annotation to the cache and registers  to monitor all modifications.
        /// If an annotation is modified by the user this modification  must be propagated
        /// to the server.
        /// </summary>
        /// <param name="annotation">the annotation</param>
        private void AddCachedAnnotation(Annotation annotation)
        {
            lock (_cachedAnnotations)
            {
                _cachedAnnotations.Add(annotation.Id, annotation);
                annotation.AuthorChanged += new AnnotationAuthorChangedEventHandler(OnClientAnnotationAuthorChanged);
                annotation.AnchorChanged += new AnnotationResourceChangedEventHandler(OnClientAnnotationAnchorChanged);
                annotation.CargoChanged += new AnnotationResourceChangedEventHandler(OnClientAnnotationCargoChanged);
            }
        }

        /// <summary>
        /// Remove an annotation from the cache and stop listening to the events
        /// </summary>
        /// <param name="annotation"></param>
        private void DeleteCachedAnnotation(Annotation annotation)
        {
            lock (_cachedAnnotations)
            {
                if (_cachedAnnotations.ContainsKey(annotation.Id))
                {
                    _cachedAnnotations.Remove(annotation.Id);
                    annotation.AuthorChanged -= new AnnotationAuthorChangedEventHandler(OnClientAnnotationAuthorChanged);
                    annotation.AnchorChanged -= new AnnotationResourceChangedEventHandler(OnClientAnnotationAnchorChanged);
                    annotation.CargoChanged -= new AnnotationResourceChangedEventHandler(OnClientAnnotationCargoChanged);
                }
            }
        }

        /// <summary>
        /// For each annotation in the list checks if it already exists - 
        /// if yes - get the existing one; if no - add  this  one to the cache
        /// </summary>
        /// <param name="list"></param>
        private void UpdateAnnotationList(IList<Annotation> list)
        {
            lock (_cachedAnnotations)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    Annotation ann = FindCachedAnnotation(list[i].Id);
                    if (ann != null)
                    {
                        list[i] = ann;
                    }
                    else
                    {
                        AddCachedAnnotation(list[i]);
                    }
                }
            }
        }

        /// <summary>
        /// Checks _changedFromStoreAnnotations array with lock to prevent changes at
        /// the moment
        /// </summary>
        /// <param name="annotationId">the annotationId to check for</param>
        /// <returns>true - available, false - not</returns>
        private bool IsChangedFromStoreAnnotation(Guid annotationId)
        {
            lock (_changedFromStoreAnnotations)
            {
                return _changedFromStoreAnnotations.Contains(annotationId);
            }
        }

        /// <summary>
        /// Adds an annotationId to _changedFromStoreAnnotations array with lock to prevent 
        /// changes at the moment
        /// </summary>
        /// <param name="annotationId">the annotationId to be added</param>
        private void AddChangedFromStoreAnnotation(Guid annotationId)
        {
            lock (_changedFromStoreAnnotations)
            {
                _changedFromStoreAnnotations.Add(annotationId);
            }
        }

        /// <summary>
        /// Removes an annotationId from _changedFromStoreAnnotations array with lock to prevent 
        /// changes at the moment
        /// </summary>
        /// <param name="annotationId">the annotationId to be removed</param>
        private void RemoveChangedFromStoreAnnotation(Guid annotationId)
        {
            lock (_changedFromStoreAnnotations)
            {
                _changedFromStoreAnnotations.Remove(annotationId);
            }
        }

        /// <summary>
        /// Called when annotation anchor or cargo is changed on the server. If this annotation
        /// is chached on our client the appropriate event is fired to update the cached resource
        /// </summary>
        /// <param name="annotationId">Id of changed annotation</param>
        /// <param name="resourceId">Id of the resource - if it is removed we have to
        /// find the cached resource and do not need to deserialize input data</param>
        /// <param name="type">Type of changed resource - anchor or cargo</param>
        /// <param name="action">added, removed or modified</param>
        /// <param name="resource">serialized resource</param>
        private void OnServerAnnotationResourceChanged(Guid annotationId, Guid resourceId, ResourceType type, int action, byte[] resource)
        {
            //if we are modifying this annotation at the moment
            // the corresponding function will fire the event
            if (!_changedFromClientAnnotations.Contains(annotationId))
            {
                Annotation sAnnotation = FindCachedAnnotation(annotationId);
                //we care only about changes in cached annotations
                if (sAnnotation != null)
                {
                    AnnotationAction sAction = Helper.ConvertAnnotationAction(action);
                    AnnotationResource sResource = null;
                    if (sAction == AnnotationAction.Removed)
                    {
                        IList<AnnotationResource> resourceList = type == ResourceType.Anchor ?
                          sAnnotation.Anchors : sAnnotation.Cargos;
                        //we must find the original resource
                        foreach (AnnotationResource aResource in resourceList)
                        {
                            if (aResource.Id == resourceId)
                            {
                                sResource = aResource;
                            }
                        }
                        if (sResource == null)
                        {
                            throw new XmlWCFStoreException("anchor is already removed");
                        }
                    }
                    else
                    {
                        sResource = Helper.DeserializeResource(resource);
                    }
                    AnnotationResourceChangedEventArgs e = new AnnotationResourceChangedEventArgs(sAnnotation, sAction, sResource);
                    DispatcherOperationCallback callback = type == ResourceType.Anchor ?
                        new DispatcherOperationCallback(ProcessAnchorCallback) :
                        new DispatcherOperationCallback(ProcessCargoCallback);
                    if (_dispatcher != null)
                    {
                        _dispatcher.BeginInvoke(DispatcherPriority.Background, callback, e);
                    }
                    else
                    {
                        callback(e);
                    }
                }
            }
        }

        #endregion Helper functions

        #endregion Private Methods

        #region Private Data

        //used to mark which resource should be processed in OnServerAnnotationResourceChanged
        private enum ResourceType
        {
            Anchor,
            Cargo
        };

        private IXmlWCFStoreService _client;  //the proxy to the server part of the store
        //we should always return the same copy of an annotation. That is why we need to cache all the annotations
        //processed by this store.
        private Dictionary<Guid, Annotation> _cachedAnnotations = new Dictionary<Guid, Annotation>();
        //if an annotation is changed by another client a store notification will be send.
        //We need to post processing of this notification in the Dispatcher thread because
        //the notification thread is not allowed to modify UI elements.
        private List<Guid> _changedFromStoreAnnotations = new List<Guid>();
        //if an annotation is changed by this client we process it synchronosly and send notification
        //to the server store, so it will propagate it to the other clients
        private List<Guid> _changedFromClientAnnotations = new List<Guid>();
        //if an annotation is added/deleted by this client we process it synchronosly and send notification
        //to the server store, so it will propagate it to the other clients
        private List<Guid> _changedFromClientStoreContent = new List<Guid>();
        //the Dispatcher of the AnnotationService thread.
        private Dispatcher _dispatcher = null;
        //we need to synchronize access to the dispatcher from the client and the Store
        private Object _syncRoot = new Object();

        #endregion Private Data

    }

}
