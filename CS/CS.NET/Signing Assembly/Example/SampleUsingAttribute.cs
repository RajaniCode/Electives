using System.Reflection;

[assembly:AssemblyKeyFileAttribute(@"C:\Users\Rajani\Desktop\.NET 4.0\Assembly\Signing Assembly\Example\keyPair.snk")]
namespace Mathematics
{  
    class Maths
    {
	public int IntegerSquare(int Number)
        {
	    return Number * Number;	   
        }	
    }
}