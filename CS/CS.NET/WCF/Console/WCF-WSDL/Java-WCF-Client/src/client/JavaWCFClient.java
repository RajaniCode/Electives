package client;

import static java.lang.System.out;
import java.net.URL;

import javax.xml.namespace.QName;
import javax.xml.ws.BindingProvider;

import org.tempuri.IWCFService;
import org.tempuri.WCFService;

public class JavaWCFClient {
    public static void main(String[] strArgs) {
	try {			
	    WCFService srv = new WCFService(new URL("http://localhost:8000/WCFService.svc?wsdl"), new QName("http://tempuri.org/", "WCFService"));
	    IWCFService port = srv.getBasicHttpBindingIWCFService();
	    ((BindingProvider)port).getRequestContext().put(BindingProvider.ENDPOINT_ADDRESS_PROPERTY, "http://localhost:8000/WCFService.svc");
	    String strOutput = port.getData("Java WCF Client");
	    out.println(strOutput);
        }
	catch(Exception e) {
	    e.printStackTrace();
	}	
    }
}