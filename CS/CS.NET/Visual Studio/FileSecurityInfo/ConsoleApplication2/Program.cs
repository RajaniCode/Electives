using System;
using System.IO;
using System.Security.AccessControl;
using System.Security.Principal;

namespace ConsoleApplication2
{
class Program
{
    static void Main(string[] args)
    {
        string dirLocation = @"C:\Program Files\IIS\Microsoft Web Deploy\";
        // IEnumerable<FileInfo> new to .NET 4.0
        var fileInfo = new DirectoryInfo(dirLocation)
                        .EnumerateFiles();

        foreach (var file in fileInfo)
        {
            Console.WriteLine("----Access Control List Entries for {0}---- \n",
                        file.Name);            
            FileSecurity fileSec = file.GetAccessControl();
            var authRuleColl =
                   fileSec.GetAccessRules(true, true, typeof(NTAccount));
            foreach (FileSystemAccessRule fsaRule in authRuleColl)
            {
                Console.WriteLine("IdentityReference: {0}", 
                    fsaRule.IdentityReference);
                Console.WriteLine("AccessControlType: {0}", 
                    fsaRule.AccessControlType);
                Console.WriteLine("FileSystemRights: {0}", 
                    fsaRule.FileSystemRights);
                Console.WriteLine();
            }
            Console.WriteLine("---------------------------");
        }

        Console.ReadLine();
    }
}
}
