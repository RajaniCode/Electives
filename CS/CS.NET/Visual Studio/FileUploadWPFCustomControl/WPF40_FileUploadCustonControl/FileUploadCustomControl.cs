using System.Windows;
using System.Windows.Controls;
using Microsoft.Win32;

namespace WPF40_FileUploadCustonControl
{
    /// <summary>
    /// Follow steps 1a or 1b and then 2 to use this custom control in a XAML file.
    ///
    /// Step 1a) Using this custom control in a XAML file that exists in the current project.
    /// Add this XmlNamespace attribute to the root element of the markup file where it is 
    /// to be used:
    ///
    ///     xmlns:MyNamespace="clr-namespace:WPF40_FileUploadCustonControl"
    ///
    ///
    /// Step 1b) Using this custom control in a XAML file that exists in a different project.
    /// Add this XmlNamespace attribute to the root element of the markup file where it is 
    /// to be used:
    ///
    ///     xmlns:MyNamespace="clr-namespace:WPF40_FileUploadCustonControl;assembly=WPF40_FileUploadCustonControl"
    ///
    /// You will also need to add a project reference from the project where the XAML file lives
    /// to this project and Rebuild to avoid compilation errors:
    ///
    ///     Right click on the target project in the Solution Explorer and
    ///     "Add Reference"->"Projects"->[Select this project]
    ///
    ///
    /// Step 2)
    /// Go ahead and use your control in the XAML file.
    ///
    ///     <MyNamespace:CustomControl1/>
    ///
    /// </summary>
     

    // Demo Created for www.dotnetcurry.com by Mahesh Sabnis
    public class FileUploadCustomControl : Control
    {

        TextBox txtFileName = null;
        Button btnBrowse = null;
        static FileUploadCustomControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(FileUploadCustomControl), new FrameworkPropertyMetadata(typeof(FileUploadCustomControl)));
        }



        public string FileName
        {
            get { return (string)GetValue(FileNameProperty); }
            set { SetValue(FileNameProperty, value); }
        }

        // Using a DependencyProperty as the backing store for FileName.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty FileNameProperty =
            DependencyProperty.Register("FileName", typeof(string), typeof(FileUploadCustomControl),
                new FrameworkPropertyMetadata(string.Empty, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));



        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            txtFileName = this.Template.FindName("TXT_FILE_NAME", this) as TextBox;

            btnBrowse = this.Template.FindName("BTN_BROWSE_FILE", this) as Button;
            btnBrowse.Click += new RoutedEventHandler(btnBrowse_Click);
            txtFileName.TextChanged += new TextChangedEventHandler(txtFileName_TextChanged); 
        }

        void btnBrowse_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fileDIalog = new OpenFileDialog();
            fileDIalog.Filter = "Image files (*.bmp, *.jpg)|*.bmp;*.jpg|Doc Files (*.doc;*.docx)|*.doc;*.docx";
            fileDIalog.AddExtension = true;
            if (fileDIalog.ShowDialog() == true)
            {
                FileName = fileDIalog.FileName;
                txtFileName.Text = FileName; 
            }
        }


        public event RoutedEventHandler FileNameChanged
        {
            add { AddHandler(FileNameChangedEvent, value); }
            remove { RemoveHandler(FileNameChangedEvent, value); }
        }

        public static readonly RoutedEvent FileNameChangedEvent =
            EventManager.RegisterRoutedEvent("FileNameChanged",
            RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(FileUploadCustomControl));


        void txtFileName_TextChanged(object sender, TextChangedEventArgs e)
        {
            e.Handled = true;

            base.RaiseEvent(new RoutedEventArgs(FileNameChangedEvent)); 
        }


    }
}
