
namespace WCF
{
    class WCFService : IWCFService
    {
        public string GetData(string Data)
        {
            return "Your Data: " + Data;
        }
    }
}
