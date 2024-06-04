//---------------------------------------------------------------------------
//
// Description: This is a sample for annotated viewers 
//              using shared storage through WCF service 
//
// History:  
//  10/2006 - Svetlana Simova created
//
//---------------------------------------------------------------------------
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Annotations;
using System.Windows.Media;
using System.Windows.Resources;
using System.Windows.Markup;
using System.Windows.Annotations.Storage;
using System.Windows.Xps.Packaging;


namespace AnnotatedViewers
{
    public partial class AnnotatedViewersApp
    {
        /// <summary>
        /// AnnotatedViewerApp ctor. Saves the server name
        /// </summary>
        /// <param name="server">server name - \\machine_name\shared_folder</param>
        public AnnotatedViewersApp(string server)
        {
            if (server == null)
            {
                throw new ArgumentNullException();
            }

            _server = server;
        }

        #region Internal Methods

        /// <summary>
        /// Initializes the documents
        /// </summary>
        /// <param name="sender">event sender - not used</param>
        /// <param name="args">event params - not used</param>
        internal void Init(object sender, EventArgs args)
        {
            ChocolateDocumentClass doc1 = new ChocolateDocumentClass();
            doc1.InitializeComponent();
            _flowDocument = (FlowDocument)doc1;

            XpsDocument xpsDocument = new
                XpsDocument(_fixedDocumentFileName, System.IO.FileAccess.Read);
            _fixedDocument = xpsDocument.GetFixedDocumentSequence();

            textNote.DataContext = inkNote.DataContext = Environment.UserName;
            highlight.DataContext = null;
        }

        /// <summary>
        /// Changes current highlight color
        /// </summary>
        /// <param name="sender">sender object</param>
        /// <param name="e">event arguments</param>
        internal void OnColorChanged(object sender, SelectionChangedEventArgs e)
        {
            Brush brush = null;

            ComboBox comboBox = sender as ComboBox;
            if (comboBox != null)
            {
                ComboBoxItem item = comboBox.SelectedItem as ComboBoxItem;
                //check thr item content ans create appropriate brush
                if (item != null)
                {
                    if (item.Content.Equals("Pink"))
                    {
                        highlight.DataContext = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#33FFC0CB"));
                    }
                    else if (item.Content.Equals("Blue"))
                    {
                        brush = Brushes.Blue.CloneCurrentValue();
                        brush.Opacity = 0.2;
                        highlight.DataContext = brush;
                    }
                    else if (item.Content.Equals("Yellow"))
                    {
                        brush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#66FFFF00"));
                        brush.Opacity = 0.5;
                        highlight.DataContext = brush;
                    }
                    else if (item.Content.Equals("Default"))
                    {
                        highlight.DataContext = null;
                    }
                }
            }
        }

        /// <summary>
        /// Loads a fixed document
        /// </summary>
        /// <param name="sender">sender object - not used</param>
        /// <param name="args">event arguments - not used</param>
        internal void LoadFixedDocument(object sender, System.Windows.RoutedEventArgs args)
        {
            LoadDocument(typeof(DocumentViewer), _fixedDocument);
        }

        /// <summary>
        /// Loads a flow document page viewer
        /// </summary>
        /// <param name="sender">sender object - not used</param>
        /// <param name="args">event arguments - not used</param>
        internal void LoadFlowDocumentPageViewer(object sender, System.Windows.RoutedEventArgs args)
        {
            LoadDocument(typeof(FlowDocumentPageViewer), _flowDocument);
        }

        /// <summary>
        /// Loads a flow document reader
        /// </summary>
        /// <param name="sender">sender object - not used</param>
        /// <param name="args">event arguments - not used</param>
        internal void LoadFlowDocumentReader(object sender, System.Windows.RoutedEventArgs args)
        {
            LoadDocument(typeof(FlowDocumentReader), _flowDocument);
        }

        /// <summary>
        /// Loads a flow document scroll viewer
        /// </summary>
        /// <param name="sender">sender object - not used</param>
        /// <param name="args">event arguments - not used</param>
        internal void LoadFlowDocumentScrollViewer(object sender, System.Windows.RoutedEventArgs args)
        {
            LoadDocument(typeof(FlowDocumentScrollViewer), _flowDocument);
        }

        /// <summary>
        /// Clears loaded document
        /// </summary>
        /// <param name="sender">sender object - not used</param>
        /// <param name="args">event arguments - not used</param>
        internal void ClearContent(object sender, System.Windows.RoutedEventArgs args)
        {
            if (_content != null)
            {
                Cleanup();

                // Clear the content by simply setting it to null.
                SetDocument(null);
                _content = null;
            }
        }

        /// <summary>
        /// Enables annotations on the current document
        /// </summary>
        /// <param name="sender">sender object - not used</param>
        /// <param name="args">sender arguments - not used</param>
        internal void EnableAnnotations(object sender, System.Windows.RoutedEventArgs args)
        {
            if (!_service.IsEnabled)
            {
                // If previously disabled, the store was closed so we recreate it
                if (_store == null)
                {
                    CreateStoreForContent();
                }

                _service.Enable(_store);
            }
        }

        /// <summary>
        /// Disables annotations on the current document
        /// </summary>
        /// <param name="sender">sender object - not used</param>
        /// <param name="args">sender arguments - not used</param>
        internal void DisableAnnotations(object sender, System.Windows.RoutedEventArgs args)
        {
            if (_service.IsEnabled)
            {
                Cleanup();
            }
        }

        /// <summary>
        /// Flushes and closes current store, Disables the annotations and returns prvious Annotations state
        /// </summary>
        /// <returns>previous annotations state</returns>
        internal bool Cleanup()
        {
            // Save all annotations and close disable the service
            bool wasEnabled = false;
            if (_viewer == null)
            {
                // Enable it by default when its the first viewer
                wasEnabled = true;
            }
            else
            {
                if (_service.IsEnabled)
                {
                    _service.Disable();
                    wasEnabled = true;
                }
                if (_store != null)
                {
                    _store.Flush();
                    _store.Dispose();
                    _store = null;
                }
            }
            return wasEnabled;
        }

        /// <summary>
        /// Creates AnnotationService for the current viewer
        /// </summary>
        internal void CreateService()
        {
            if (_viewer is DocumentViewerBase)
            {
                _service = new AnnotationService((DocumentViewerBase)_viewer);
            }
            else if (_viewer is FlowDocumentScrollViewer)
            {
                _service = new AnnotationService((FlowDocumentScrollViewer)_viewer);
            }
            else if (_viewer is FlowDocumentReader)
            {
                _service = new AnnotationService((FlowDocumentReader)_viewer);
            }
        }

        /// <summary>
        /// Loads appropriate document in  the current viewer
        /// </summary>
        /// <param name="source">The document to be loaded</param>
        internal void SetDocument(IDocumentPaginatorSource source)
        {
            if (_viewer is DocumentViewerBase)
            {
                ((DocumentViewerBase)_viewer).Document = source;
            }
            else if (_viewer is FlowDocumentScrollViewer)
            {
                ((FlowDocumentScrollViewer)_viewer).Document = (FlowDocument)source;
            }
            else if (_viewer is FlowDocumentReader)
            {
                ((FlowDocumentReader)_viewer).Document = (FlowDocument)source;
            }
        }

        /// <summary>
        /// Replaces the current viewer by one of the new viewerType and loads passed document.
        /// Keeps the Annotations Enable/Disable state as is
        /// </summary>
        /// <param name="viewerType">the new viewer type</param>
        /// <param name="document">the new document</param>
        internal void LoadDocument(Type viewerType, IDocumentPaginatorSource document)
        {
            if (_content != document || _viewer == null || !_viewer.GetType().Equals(viewerType))
            {
                bool reEnable = Cleanup();

                _content = document;

                if (_viewer == null || !(_viewer.GetType().Equals(viewerType)))
                {
                    SetDocument(null);
                    _viewer = (FrameworkElement)Activator.CreateInstance(viewerType);
                    Holder.Child = _viewer;
                    CreateService();
                    reEnable = true;
                }

                // Enable annotations for the new content
                CreateStoreForContent();

                // Set content on viewer
                SetDocument(_content);

                DocumentViewer docViewer = _viewer as DocumentViewer;
                if (docViewer != null)
                    docViewer.FitToHeight();

                // Reenable service if necessary
                if (reEnable)
                {
                    _service.Enable(_store);
                }
            }
        }

        /// <summary>
        /// Create different store for flow or fixed content
        /// </summary>
        internal void CreateStoreForContent()
        {
            string name = null;
            if (_content is FlowDocument)
            {
                name = _flowStoreName;
            }
            else if (_content is FixedDocumentSequence)
            {
                name = _fixedStoreName;
            }
            _store = new XmlWCFStore.XmlWCFStore(_server, name, _viewer.Dispatcher);
        }

        #endregion Internal Methods

        #region Protected Methods

        /// <summary>
        /// Saves the annotations and exits
        /// </summary>
        /// <param name="args"><not used/param>
        protected override void OnClosing(CancelEventArgs args)
        {
            Cleanup();
            Environment.Exit(0);
        }

        #endregion Protected Methods

        #region Private Data

        /// <summary>
        /// Private Data
        /// </summary>

        //current flow  document if loade
        private FlowDocument _flowDocument;
        //current fixed document if loaded
        private FixedDocumentSequence _fixedDocument;
        //current viewer
        private FrameworkElement _viewer;
        // current AnnotationsStore;
        private AnnotationStore _store = null;
        // current AnnotationsService
        private AnnotationService _service = null;
        //current Document
        private IDocumentPaginatorSource _content = null;
        //the name of server for store
        private string _server;
        //AnnotationStore name for flow document
        private const string _flowStoreName = "FlowStore.xml";
        //AnnotationStore name for fixed document
        private const string _fixedStoreName = "FixedStore.xml";
        //Fixed document file name
        private const string _fixedDocumentFileName = "Cocoa.xps";

        #endregion Private Data

    }
}

