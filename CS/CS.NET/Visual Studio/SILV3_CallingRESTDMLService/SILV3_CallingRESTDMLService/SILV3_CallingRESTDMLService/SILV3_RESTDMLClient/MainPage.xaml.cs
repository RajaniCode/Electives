using System;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.IO;

using System.Windows.Browser;

using System.Xml.Linq;

namespace SILV3_RESTDMLClient
{
    public partial class MainPage : UserControl
    {
        WebClient webClient;
        public MainPage()
        {
            InitializeComponent();
        }

private void btnInsert_Click(object sender, RoutedEventArgs e)
{
    try
    {
        string uploadUrl = "http://localhost/RESTVDDML/Service.svc/CreateEmployee/" + txteno.Text + "/" + txtename.Text + "/" + txtsal.Text + "/" + txtdno.Text  ;
        WebRequest addRequest = WebRequest.Create(uploadUrl);
        addRequest.Method = "POST";
        //Begin the Asynchrnous Request
        addRequest.BeginGetRequestStream(CallBackAddRequest,addRequest);  
    }
    catch (Exception ex)
    {
        HtmlPage.Window.Alert(ex.Message); 
    }
}

void CallBackAddRequest(IAsyncResult ar)
{
    //Contains information of the Async object containing Request Information
    WebRequest req = (WebRequest)ar.AsyncState;
                        //Returns stream for writing data to the Web Resource
    Stream reqStream = req.EndGetRequestStream(ar);
    reqStream.Close();

    //Now Collect the response Asynchronously
    req.BeginGetResponse(CallBackResponse, req);   
}
//Response Callback, is mandatory to complete operations on the receiving end
void CallBackResponse(IAsyncResult ar)
{
    try
    {
        WebRequest req = (WebRequest)ar.AsyncState;
        //Collect the reponse
        WebResponse res = req.EndGetResponse(ar);
        Stream strResult = res.GetResponseStream();

        strResult.Close();
        res.Close();
    }
    catch (Exception ex)
    {
        string s = ex.Message;
    }
}



private void btnDelete_Click(object sender, RoutedEventArgs e)
{
    string delUrl = "http://localhost/RESTVDDML/Service.svc/DeleteEmployee/" + txteno.Text;
    //Create WebRequest Object
    WebRequest delRequest = WebRequest.Create(delUrl);
   delRequest.Method = "POST";
    //Make the Asynchronius Call
    delRequest.BeginGetRequestStream(CallBackDeleteRequest,delRequest);  
}

//The Async Delete CallBack
void CallBackDeleteRequest(IAsyncResult ar)
{
    //Contains information of the Async object containing Request Information
    WebRequest req = (WebRequest)ar.AsyncState;
    //Returns stream for writing data to the Web Resource
    Stream reqStream = req.EndGetRequestStream(ar);
    reqStream.Close();

    //Now Collect the response Asynchronously
    req.BeginGetResponse(CallBackResponse, req);   
}

private void btnGetAll_Click(object sender, RoutedEventArgs e)
{
    webClient = new WebClient();
    webClient.DownloadStringCompleted+=new DownloadStringCompletedEventHandler(webClient_DownloadStringCompleted);
    webClient.DownloadStringAsync(new Uri("http://localhost/RESTVDDML/Service.svc/GetAllEmployee", UriKind.Absolute));  
    

}

void webClient_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
{
    XDocument xDoc = XDocument.Parse(e.Result);

    var AllEmps = from Emp in xDoc.Descendants("Employee")
                  select new Employee()
                  {
                      EmpNo = Convert.ToInt32(Emp.Descendants("EmpNo").First().Value ),
                      EmpName = Emp.Descendants("EmpName").First().Value,
                      Salary = Convert.ToInt32(Emp.Descendants("Salary").First().Value),
                      DeptNo = Convert.ToInt32(Emp.Descendants("DeptNo").First().Value)
                  };
    grdEmployee.DataContext = AllEmps.ToList();  
}

       
        
    }
}
