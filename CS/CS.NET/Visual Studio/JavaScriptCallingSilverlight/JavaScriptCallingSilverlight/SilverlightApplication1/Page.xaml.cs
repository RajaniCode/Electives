using System;
using System.Collections.ObjectModel;
using System.Windows.Browser;
using System.Windows.Controls;

namespace SilverlightApplication1
{
    public partial class Page : UserControl
    {
        public Page()
        {
            InitializeComponent();            
            HtmlPage.RegisterScriptableObject("SilverlightPostCode", this);
        }
                
        [ScriptableMember(ScriptAlias = "SearchPostCode")]
        public void InternalNameOnly(string postCode)
        {
            PostCodeServiceReference.PostCodeServiceClient client = new PostCodeServiceReference.PostCodeServiceClient();
            client.DoWorkCompleted += new EventHandler<SilverlightApplication1.PostCodeServiceReference.DoWorkCompletedEventArgs>(client_DoWorkCompleted);
            client.DoWorkAsync(postCode);            
        }

        void client_DoWorkCompleted(object sender, SilverlightApplication1.PostCodeServiceReference.DoWorkCompletedEventArgs e)
        {
            HtmlElement parent = HtmlPage.Document.GetElementById("sampleDiv");
            parent.SetAttribute("innerHTML", string.Empty);
            ObservableCollection<PostCodeServiceReference.AddressInfo> addresses = e.Result;

            if (addresses.Count > 0)
            {
                HtmlElement ul = HtmlPage.Document.CreateElement("ul");
                foreach (PostCodeServiceReference.AddressInfo item in addresses)
                {
                    HtmlElement li = HtmlPage.Document.CreateElement("li");
                    li.SetAttribute("innerHTML", string.Format("{0} ({1})", item.Suburb, item.State));
                    ul.AppendChild(li);
                }
                parent.AppendChild(ul);
            }
            else
            {
                HtmlElement p = HtmlPage.Document.CreateElement("p");
                p.SetAttribute("innerHTML", "No records found");
                parent.AppendChild(p);
            }
        }        
    }
}
