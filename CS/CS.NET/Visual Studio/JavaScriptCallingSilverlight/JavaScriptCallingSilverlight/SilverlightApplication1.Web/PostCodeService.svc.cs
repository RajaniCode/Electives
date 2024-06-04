using System.Collections.Generic;
using System.Data;
using System.ServiceModel;
using System.ServiceModel.Activation;
using SilverlightApplication1.Web.au.com.ssw.webservices;

namespace SilverlightApplication1.Web
{
    [ServiceContract(Namespace = "")]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class PostCodeService
    {
        [OperationContract]
        public List<AddressInfo> DoWork(string code)
        {
            List<AddressInfo> addresses = new List<AddressInfo>();
            PostcodeService postCode = new PostcodeService();
            DataSet ds = postCode.GetPostcodeAndSuburbForAustralia(string.Empty, string.Empty, code);

            if (ds.Tables[0] != null)
            {
                foreach (DataRow item in ds.Tables[0].Rows)
                {
                    addresses.Add(new AddressInfo()
                    {
                        Suburb = item[0] as string,
                        Postcode = item[1] as string,
                        State = item[2] as string                        
                    });
                }
            }
            return addresses;
        }        
    }
}
