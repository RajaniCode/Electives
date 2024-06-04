// Client.cs 

using System;
using System.Runtime.Remoting;

public class Client{

   public static void Main(){
      RemotingConfiguration.Configure("Client.exe.config");
      RemotableType remoteObject = new RemotableType();
      Console.WriteLine(remoteObject.SayHello());
   }
}