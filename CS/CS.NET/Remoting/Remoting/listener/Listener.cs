// Listener.cs

using System;
using System.Runtime.Remoting;

public class Listener
{
    public static void Main(string[] args)
    {
        RemotingConfiguration.Configure("Listener.exe.config", false);
        Console.WriteLine("Listening for requests. Press enter to exit...");
        Console.ReadLine();
    }
}