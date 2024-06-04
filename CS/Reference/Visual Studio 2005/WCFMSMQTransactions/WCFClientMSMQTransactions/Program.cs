using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;

namespace WCFClientMSMQTransactions
{
    class Program
    {
        static void Main(string[] args)
        {
            
            InterfaceMSMQProxy objProxy = new InterfaceMSMQProxy();
            using (TransactionScope objtrans = new TransactionScope(TransactionScopeOption.Required))
            {
                for (int i = 0; i < 10; i++)
                {
                    objProxy.readMessage("HI this is a offline message to the server");
                }

                string stryesno = "";
                Console.WriteLine("Press y to commit");

                stryesno = Console.ReadLine().ToLower();
                if (stryesno.Equals("y"))
                {
                    objtrans.Complete();
                }
                else
                {
                    objtrans.Dispose();
                }
                
            }
            Console.ReadLine();
        }
    }
}
