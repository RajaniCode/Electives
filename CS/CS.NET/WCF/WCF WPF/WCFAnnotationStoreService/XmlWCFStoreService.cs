//---------------------------------------------------------------------------
//
// Description: Defines the IXmlWCFStoreService interface  and 
// the client callback interface - IXmlWCFStore
//
// History:  
//  10/2006 - Svetlana Simova created 
//
//---------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Text;
using System.ServiceModel;
using System.Runtime.Serialization;
using System.Windows.Annotations;
using System.Xml;
using System.IO;

namespace XmlWCFStore
{
    /// <summary>
    /// The service contract for the XmlWCFStore
    /// </summary>
    [ServiceContract(CallbackContract = typeof(IXmlWCFStore), SessionMode = SessionMode.Required)]
    public interface IXmlWCFStoreService
    {
        /// <summary>
        /// Open a store for the client. If a XmlStreamStore with this name exists
        /// registers the client with the existing store data
        /// </summary>
        /// <param name="name">store name</param>
        [OperationContract(IsInitiating = true, IsTerminating = false)]
        void OpenStore(string name);

        /// <summary>
        /// Close a store. The client is unregistered from this store. If there are no more 
        /// registered clients the XmlStreamStore is closed.
        /// </summary>
        [OperationContract(IsInitiating = false, IsTerminating = false)]
        void CloseStore();

        /// <summary>
        ///     Add a new annotation to this store.  The new annotation's Id
        ///     is set to a new value.
        /// </summary>
        /// <param name="newAnnotation">the annotation to be added to the store</param>
        /// <exception cref="ArgumentNullException">newAnnotation is null</exception>
        /// <exception cref="ArgumentException">newAnnotation already exists in this store, as determined by its Id</exception>
        /// <exception cref="ObjectDisposedException">if object has been disposed</exception>
        [OperationContract(IsInitiating = false, IsTerminating = false)]
        void AddAnnotation(byte[] newAnnotation);

        /// <summary>
        ///     Delete the specified annotation.
        /// </summary>
        /// <param name="annotationId">the Id of the annotation to be deleted</param>
        /// <returns>the annotation that was deleted</returns>
        /// <exception cref="ObjectDisposedException">if object has been disposed</exception>
        [OperationContract(IsInitiating = false, IsTerminating = false)]
        byte[] DeleteAnnotation(Guid annotationId);

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
        [OperationContract(IsInitiating = false, IsTerminating = false)]
        byte[] GetAnnotationsByLocator(byte[] anchorLocator);

        /// <summary>
        /// Returns a list of all annotations in the store
        /// </summary>
        /// <exception cref="ObjectDisposedException">if object has been disposed</exception>
        /// <returns>annotations list. Can return an empty list, but never null.</returns>
        [OperationContract(IsInitiating = false, IsTerminating = false)]
        byte[] GetAnnotations();

        /// <summary>
        /// Finds annotation by Id
        /// </summary>
        /// <param name="annotationId"></param>
        /// <exception cref="ObjectDisposedException">if object has been disposed</exception>
        /// <returns>The annotation. Null if the annotation does not exists</returns>
        [OperationContract(IsInitiating = false, IsTerminating = false)]
        byte[] GetAnnotation(Guid annotationId);

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
        [OperationContract(IsInitiating = false, IsTerminating = false)]
        void Flush();

        /// <summary>
        /// The client part uses this to notify the server when there are changes 
        /// in the annotation author
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        [OperationContract(IsInitiating = false, IsTerminating = false)]
        void ProcessAuthor(Guid annotationId, int action, string author);

        /// <summary>
        /// The client part uses this to notify the server when there are changes 
        /// in the annotation anchor
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        [OperationContract(IsInitiating = false, IsTerminating = false)]
        void ProcessAnchor(Guid annotationId, int action, byte[] resource);

        /// <summary>
        /// The client part uses this to notify the server when there are changes 
        /// in the annotation cargo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        [OperationContract(IsInitiating = false, IsTerminating = false)]
        void ProcessCargo(Guid annotationId, int action, byte[] resource);

        /// <summary>
        /// Get current AutoFlush mode
        /// </summary>
        /// <returns>current autoFlush mode</returns>
        [OperationContract(IsInitiating = false, IsTerminating = false)]
        bool GetAutoFlush();

        /// <summary>
        /// Sets current AutoFlush mode
        /// </summary>
        /// <param name="mode">new AutoFlush mode</param>
        [OperationContract(IsInitiating = false, IsTerminating = false)]
        void SetAutoFlush(bool mode);

    }

    /// <summary>
    /// The callback interface for the client. Through this interface the service notifies
    /// the clients about changes in the store
    /// </summary>
    [ServiceContract(SessionMode = SessionMode.Required)]
    public interface IXmlWCFStore
    {
        /// <summary>
        /// Called  when annotations are added or removed from the store
        /// </summary>
        /// <param name="annotation">the annotation</param>
        /// <param name="action">the action</param>
        [OperationContract(IsOneWay=true)]
        void OnServerStoreContentChanged(byte[] annotation, int action);

        /// <summary>
        /// Called  when annotation author is changed
        /// </summary>
        /// <param name="annotationId">the annotation id</param>
        /// <param name="action">the action</param>
        /// <param name="author">the new author value</param>
        [OperationContract(IsOneWay = true)]
        void OnServerAnnotationAuthorChanged(Guid annotationId, int action, string author);

        /// <summary>
        /// Called  when annotation anchor is changed
        /// </summary>
        /// <param name="annotationId">the annotation id</param>
        /// <param name="action">the action</param>
        /// <param name="anchor">the new anchor value</param>
        [OperationContract(IsOneWay = true)]
        void OnServerAnnotationAnchorChanged(Guid annotationId, Guid resourceId, int action, byte[] resource);

        /// <summary>
        /// Called  when annotation cargo is changed
        /// </summary>
        /// <param name="annotationId">the annotation id</param>
        /// <param name="action">the action</param>
        /// <param name="anchor">the new cargo value</param>
        [OperationContract(IsOneWay = true)]
        void OnServerAnnotationCargoChanged(Guid annotationId, Guid resourceId, int action, byte[] resource);
    }
}
