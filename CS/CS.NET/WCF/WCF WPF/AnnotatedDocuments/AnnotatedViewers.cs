//---------------------------------------------------------------------------
// 
// Description: This is a sample for annotated viewers 
//              using shared storage through WCF service 
//
// History:  
//  10/2006 - Svetlana Simova created based on RRuiz DRT
//
//---------------------------------------------------------------------------

using System;
using System.Collections;
using System.Reflection;
using System.Windows;
using System.Windows.Navigation;
using System.Windows.Resources;

namespace AnnotatedViewers
{
    /// <summary>
    /// This class contains the main function
    /// </summary>
    public sealed class AnnotatedViewersMain
    {
        [STAThread]
        public static int Main(string[] args)
        {
            string server = "localhost";
            if ((args != null) && (args.Length > 0))
            {
                server = args[0];
            }

            AnnotatedViewersApp window = new AnnotatedViewersApp(server);
            window.InitializeComponent();
            window.Visibility = Visibility.Visible;

            window.LoadFlowDocumentPageViewer(null, null);
            window.Show();

            Application app = new Application();
            app.Run();

            return 0;
        }

    }
}

