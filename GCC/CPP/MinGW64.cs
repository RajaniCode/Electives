using System;
using System.Text;
using System.Runtime.InteropServices;

class Program
{
    [DllImport("msys64-mingw64.dll", CharSet=CharSet.Unicode)]
    unsafe public static extern char* hello(char* b);

    [DllImport("msys64-mingw64.dll", CharSet=CharSet.Unicode)]
    unsafe public static extern char* hello_world(char* a, char* b);

    static void Main()
    { 
        string w = "World!";
        unsafe 
        {
            IntPtr iptr = Marshal.StringToHGlobalAnsi(w);
            char* cptr = (char*)iptr.ToPointer();
            char* cp = hello(cptr);
            Console.WriteLine(Marshal.PtrToStringAnsi((IntPtr)cp));
        }


        string h = "Hello, ";
        unsafe 
        {
            IntPtr iptrh = Marshal.StringToHGlobalAnsi(h);
            IntPtr iptrw = Marshal.StringToHGlobalAnsi(w);
            char* cptrh = (char*)iptrh.ToPointer();
            char* cptrw = (char*)iptrw.ToPointer();
            char* cphw = hello_world(cptrh, cptrw);
            Console.WriteLine(Marshal.PtrToStringAnsi((IntPtr)cphw));
        }
    }


}