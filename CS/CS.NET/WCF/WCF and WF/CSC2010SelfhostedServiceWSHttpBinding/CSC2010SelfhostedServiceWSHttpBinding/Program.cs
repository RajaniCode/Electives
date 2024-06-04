using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.ServiceModel;
using Microsoft.Samples.DurableIssuedTokenProvider;

namespace CSC2010SelfhostedServiceWSHttpBinding
{
    class Program
    {
        static void Main(string[] args)
        {
            // This string uses a function to prepend the computer name at run time.
            string addressHttp = String.Format(
                "http://{0}:8080/Calculator",
                System.Net.Dns.GetHostEntry("").HostName);

            WSHttpBinding b = new WSHttpBinding();
            b.Security.Mode = SecurityMode.Transport;
            b.Security.Transport.ClientCredentialType = HttpClientCredentialType.Certificate;

            // You must create an array of URI objects to have a base address.
            Uri a = new Uri(addressHttp);
            Uri[] baseAddresses = new Uri[] { a };

            // Create the ServiceHost. The service type (Calculator) is not
            // shown here.
            ServiceHost sh = new ServiceHost(typeof(Calculator), baseAddresses);

            // Add an endpoint to the service. Insert the thumbprint of an X.509 
            // certificate found on your computer. 
            Type c = typeof(ICalculator);
            sh.AddServiceEndpoint(c, b, "MyCalculator");
            sh.Credentials.ServiceCertificate.SetCertificate(
                StoreLocation.LocalMachine,
                StoreName.My,
                X509FindType.FindBySubjectName,
                "contoso.com");

            // This next line is optional. It specifies that the client's certificate
            // does not have to be issued by a trusted authority, but can be issued
            // by a peer if it is in the Trusted People store. Do not use this setting
            // for production code. The default is PeerTrust, which specifies that 
            // the certificate must originate from a trusted certifiate authority.

            // sh.Credentials.ClientCertificate.Authentication.CertificateValidationMode =
            // X509CertificateValidationMode.PeerOrChainTrust;
            try
            {
                sh.Open();

                string address = sh.Description.Endpoints[0].ListenUri.AbsoluteUri;
                Console.WriteLine("Listening @ {0}", address);
                Console.WriteLine("Press enter to close the service");
                Console.ReadLine();
                sh.Close();
            }
            catch (CommunicationException ce)
            {
                Console.WriteLine("A commmunication error occurred: {0}", ce.Message);
                Console.WriteLine();
            }
            catch (System.Exception exc)
            {
                Console.WriteLine("An unforseen error occurred: {0}", exc.Message);
                Console.ReadLine();
            }
        }
    }
}
