//---------------------------------------------------------------------------
// 
// Description: A helper class for serializing and deserializing annotations
//              for WCF store
//
// History:  
//  10/2006 - Svetlana Simova created 
//
//---------------------------------------------------------------------------

using System;
using System.IO;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using System.Windows.Annotations;
using System.Windows.Annotations.Storage;

namespace XmlWCFStore
{
    /// <summary>
    /// XmlWCFStoreException
    /// </summary>
    public class XmlWCFStoreException : Exception
    {
        public XmlWCFStoreException(string message):base(message)
        {
        }
    }

    public class Helper
    {
        #region Public Methods

        /// <summary>
        /// Serializes a list of annotations to a byte array
        /// </summary>
        /// <param name="annotations">annotations list</param>
        /// <returns>serialized annotations</returns>
        public static byte[] Serialize(IList<Annotation> annotations)
        {
            if (annotations == null)
            {
                throw new ArgumentNullException("annotations");
            }

            //create a MemoryStream based XmlStreamStore
            MemoryStream stream = new MemoryStream();
            XmlStreamStore store = new XmlStreamStore(stream);

            //add the annotations to the store
            foreach (Annotation ann in annotations)
            {
                store.AddAnnotation(ann);
            }

            return CloseStreamAndStore(stream, store);
        }

        /// <summary>
        /// Serializes IXmlSerializable annotation  object to a byte array.
        /// Possible object types are Annotation, AnnotationResource, ContentLocator
        /// </summary>
        /// <param name="inObject">the annotation object</param>
        /// <returns>serialized object</returns>
        public static byte[] Serialize(IXmlSerializable inObject)
        {
            if (inObject == null)
            {
                throw new ArgumentNullException("inObject");
            }
            //create a MemoryStream based XmlStreamStore
            MemoryStream stream = new MemoryStream();
            XmlStreamStore store = new XmlStreamStore(stream);
            Annotation ann = null;

            //create a temporary annotation if needed to place the object
            if (inObject is Annotation)
            {
                ann = (Annotation)inObject;
            }
            else if (inObject is AnnotationResource)
            {
                ann = new Annotation(new XmlQualifiedName("test", "ns"));
                //make a copy of the resource because the original already has a parent
                ann.Anchors.Add(CopyResource((AnnotationResource)inObject));
            }
            else if (inObject is ContentLocator)
            {
                ann = new Annotation(new XmlQualifiedName("test", "ns"));
                AnnotationResource res = new AnnotationResource();
                res.ContentLocators.Add((ContentLocator)inObject);
                ann.Anchors.Add(res);
            }
            else
            {
                throw new XmlWCFStoreException("unsupported serialization type");
            }
            store.AddAnnotation(ann);

            return CloseStreamAndStore(stream, store);
        }

        /// <summary>
        /// Deserialize a byte array to Annotations list
        /// </summary>
        /// <param name="data">the input array</param>
        /// <returns>created annotations</returns>
        public static IList<Annotation> Deserialize(byte[] data)
        {
            if (data == null)
            {
                throw new ArgumentNullException("data");
            }
            //create a MemoryStream based XmlStreamStore
            MemoryStream stream = new MemoryStream(data);
            XmlStreamStore store = new XmlStreamStore(stream);
            IList<Annotation> res = store.GetAnnotations();
            store.Dispose();
            stream.Close();
            return res;
        }

        /// <summary>
        /// Converts  a byte array to AnnotationResource
        /// </summary>
        /// <param name="data">the input array</param>
        /// <returns>Created AnnotationResource</returns>
        public static AnnotationResource DeserializeResource(byte[] data)
        {
            IList<Annotation> annotations = Deserialize(data);
            if (annotations.Count != 1)
            {
                throw (new XmlWCFStoreException("unexpected annotations count"));
            }

            if (annotations[0].Anchors.Count != 1)
            {
                throw (new XmlWCFStoreException("unexpected anchors count"));
            }

            //we must remove the resource from this parent first
            AnnotationResource res = annotations[0].Anchors[0];
            annotations[0].Anchors.RemoveAt(0);
            return res;
        }

        /// <summary>
        /// Converts an array of bytes to ContentLocator
        /// </summary>
        /// <param name="data">input array</param>
        /// <returns>created locator</returns>
        public static ContentLocator DeserializeLocator(byte[] data)
        {
            AnnotationResource resource = DeserializeResource(data);

            if (resource.ContentLocators.Count != 1)
            {
                throw (new XmlWCFStoreException("unexpected ContentLocators count"));
            }

            ContentLocator res = (ContentLocator)resource.ContentLocators[0];
            //remove the resource from its parent so it can be added to another
            resource.ContentLocators.RemoveAt(0);
            return res;
        }

        /// <summary>
        /// Converts  int to AnnotationAction
        /// </summary>
        /// <param name="action">int representation of the action</param>
        /// <returns>AnnotationAction</returns>
        public static AnnotationAction ConvertAnnotationAction(int action)
        {
            AnnotationAction annAction = AnnotationAction.Modified;
            switch (action)
            {
                case IntActionAdded:
                    annAction = AnnotationAction.Added;
                    break;
                case IntActionRemoved:
                    annAction = AnnotationAction.Removed;
                    break;
                case IntActionModified:
                    annAction = AnnotationAction.Modified;
                    break;
                default:
                    {
                        throw (new XmlWCFStoreException("unexpected int annotation action"));
                    }

            }

            return annAction;

        }

        /// <summary>
        /// Converts AnnotationAction to int
        /// </summary>
        /// <param name="action">AnnotationAction</param>
        /// <returns>int representation</returns>
        public static int ConvertActionToInt(AnnotationAction action)
        {
            int annAction = IntActionAdded;
            switch (action)
            {
                case AnnotationAction.Added:
                    annAction = IntActionAdded;
                    break;
                case AnnotationAction.Removed:
                    annAction = IntActionRemoved;
                    break;
                case AnnotationAction.Modified:
                    annAction = IntActionModified;
                    break;
            }

            return annAction;

        }

        /// <summary>
        /// Converts an int to StoreContentAction
        /// </summary>
        /// <param name="action">int representation of StoreContentAction</param>
        /// <returns>the StoreContentAction</returns>
        public static StoreContentAction ConvertIntToStoreContentAction(int action)
        {
            return action == IntStoreContentActionAdded ?
                              StoreContentAction.Added : StoreContentAction.Deleted;
        }

        /// <summary>
        /// Converts a StoreContentAction to int
        /// </summary>
        /// <param name="action">StoreContentAction</param>
        /// <returns>int representation of StoreContentAction</returns>
        public static int ConvertStoreContentActionToInt(StoreContentAction action)
        {
            return action == StoreContentAction.Added ?
                             IntStoreContentActionAdded : IntStoreContentActionDeleted;
        }

        /// <summary>
        /// Adds, removes or replaces a resource in the list
        /// </summary>
        /// <param name="list">resources list</param>
        /// <param name="action">action - add, remove, replace</param>
        /// <param name="resource">new resource</param>
        public static void ProcessResource(IList<AnnotationResource> list, int action, byte[] resource)
        {
            if (resource == null)
            {
                throw (new ArgumentNullException("resource"));
            }

            AnnotationResource anResource = DeserializeResource(resource);
            ProcessResource(list, ConvertAnnotationAction(action), anResource);
        }

        /// <summary>
        /// Adds, removes or replaces a resource in the list
        /// </summary>
        /// <param name="list">resources list</param>
        /// <param name="action">action - add, remove, replace</param>
        /// <param name="resource">new resource</param>
        public static void ProcessResource(IList<AnnotationResource> list, AnnotationAction action, AnnotationResource resource)
        {
            if (list == null)
            {
                throw (new ArgumentNullException("list"));
            }

            if (resource == null)
            {
                throw (new ArgumentNullException("resource"));
            }


            switch (action)
            {
                case AnnotationAction.Added: //add
                    list.Add(resource);
                    break;
                case AnnotationAction.Removed: //deleted
                    for (int i = 0; i < list.Count; i++)
                    {
                        if (list[i].Id.Equals(resource.Id))
                        {
                            list.RemoveAt(i);
                            break;
                        }
                    }
                    break;
                case AnnotationAction.Modified: //modified
                    int ind = 0;
                    for (; ind < list.Count; ind++)
                    {
                        if (list[ind].Id.Equals(resource.Id))
                        {
                            break;
                        }
                    }
                    if (ind < list.Count)
                    {
                        list.RemoveAt(ind);
                        list.Insert(ind, resource);
                    }
                    break;
            }
        }

        /// <summary>
        /// Adds, removes or replaces an annotation author 
        /// </summary>
        /// <param name="list">resources list</param>
        /// <param name="action">action - add, remove, replace</param>
        /// <param name="resource">new resource</param>
        public static void ProcessAuthor(Annotation ann, int action, string author)
        {
            if (ann == null)
            {
                throw (new ArgumentNullException("ann"));
            }

            switch (action)
            {
                case IntActionAdded: //add
                    ann.Authors.Add(author);
                    break;
                case IntActionRemoved: //deleted
                    string res = null;
                    foreach (string anAuthor in ann.Authors)
                    {
                        if (anAuthor.Equals(author))
                        {
                            res = anAuthor;
                            break;
                        }
                    }
                    if (res != null)
                    {
                        ann.Authors.Remove(res);
                    }
                    break;
                case IntActionModified: //modified
                    //we do not support modified authors
                    throw (new XmlWCFStoreException("author modification is not supported"));
            }
        }

        #endregion Public Methods

        #region Private Methods

        /// <summary>
        /// Makes a copy of an AnnotationResource so it can be added to another parent.
        /// Used to serialize the resource
        /// </summary>
        /// <param name="original">the original resource</param>
        /// <returns>the copy</returns>
        private static AnnotationResource CopyResource(AnnotationResource original)
        {
            AnnotationResource copy = new AnnotationResource(original.Id);
            copy.Name = original.Name;
            foreach (ContentLocatorBase locator in original.ContentLocators)
            {
                copy.ContentLocators.Add((ContentLocatorBase)(locator.Clone()));
            }
            foreach (XmlElement content in original.Contents)
            {
                copy.Contents.Add(content);
            }

            return copy;
        }

        /// <summary>
        /// Gets the MemoryStream byte array and closes the stream and the store
        /// This is called by serializing functions to get byte representation of 
        /// the annotations in the store.
        /// </summary>
        /// <param name="stream">Store MemoryStream</param>
        /// <param name="store">AnnotationStore</param>
        /// <returns></returns>
        private static byte[] CloseStreamAndStore(MemoryStream stream, AnnotationStore store)
        {
            //close the store and get underlying array
            store.Flush();
            byte [] res = stream.ToArray();
            store.Dispose();
            stream.Close();
            return res;
        }

        #endregion Private Methods

        #region Private Data

        //int representation of AnnotationAction.Added
        private const int IntActionAdded = 0;
        //int representation of AnnotationAction.Removed
        private const int IntActionRemoved = 1;
        //int representation of AnnotationAction.Modified
        private const int IntActionModified = 2;

        //int representation of StoreContentAction.Added
        private const int IntStoreContentActionAdded = 0;
        //int representation of StoreContentAction.Deleted
        private const int IntStoreContentActionDeleted = 1;

#endregion Private Data

    }
}
