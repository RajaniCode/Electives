
namespace WCF_SecureService
{
    public class Service : IService
    {
        public string[] GetNames()
        {
            return new string []{"Ajay","Rakesh","Vinod"};
        }
    }
}
