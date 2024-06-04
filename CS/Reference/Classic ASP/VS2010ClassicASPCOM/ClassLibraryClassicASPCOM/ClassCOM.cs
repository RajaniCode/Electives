using System.Runtime.InteropServices;

namespace ClassicASPCOM
{
    [ComVisibleAttribute(true)]
    [Guid("98594D8C-B919-408F-9A73-8CEBC995B7A6")]
    public interface IGetMessage
    {
        [DispId(12345)]
        string GetMessage();
    }
    
    [ComVisibleAttribute(true)]
    [Guid("030A3DFE-2449-4134-A27E-232F5AA567B7"),
    ClassInterface(ClassInterfaceType.None)]
    public class ClassCOM : IGetMessage
    {
        public string GetMessage()
        {
            return "Hello World Classic ASP COM";
        }
    }
}
