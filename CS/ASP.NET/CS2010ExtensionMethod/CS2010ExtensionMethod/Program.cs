using System;

using Original;

namespace Original
{
    class OriginalType
    {
        public void OriginalMethod(int x)
        {
            //Original Code
            Console.WriteLine("Original Functionality: x = {0}", x);
        }
    }
}

namespace Client
{
    static class Extension
    {
        public static void ExtendedMethod(this OriginalType t, int x, bool b)
        {
            t.OriginalMethod(x);

            //Extended Code
            Console.WriteLine("Extended Functionality: b = {0}", b);
        }
    }

    class MainApp
    {
        static void Main()
        {
            OriginalType t = new OriginalType();
            t.OriginalMethod(1); //Existing calls should not be disturbed

            bool b = false;

            //Pass an additional parameter viz., bool
            t.ExtendedMethod(1, b);

            Console.ReadKey();
        }
    }
}