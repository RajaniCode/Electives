using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnonymousTypeEquality
{
  class Program
  {
    static void Main(string[] args)
    {
      //creates anonymous type 1
      var audioBook = new {Artist="Bob Dylan", Song="I Shall Be Released"};
      // creates another instance reuses anonymous type 1, == returns false
      // Equals returns true
      var songBook1 = new {Artist="Bob Dylan", Song="I Shall Be Released"};
      //creates anonymous type 2 - can't use ==
      var songBook2 = new {Singer="Bob Dylan", Song="I Shall Be Released"};
      //creates anonymous type 3 - order is different
      var audioBook1 = new {Song="I Shall Be Released", Artist="Bob Dylan"};

      Console.WriteLine("audioBook hash " + audioBook.GetHashCode());
      Console.WriteLine("songBook1 hash  " + songBook1.GetHashCode());
      Console.WriteLine("songBook2 hash  " + songBook2.GetHashCode());
      Console.WriteLine("audioBook1 hash " + audioBook1.GetHashCode());
      
      Type t = audioBook.GetType();
      Console.WriteLine("audioBook Type: " + t.ToString());
      
      // Error	1	Operator '==' cannot be applied to operands of type 'AnonymousType#1' and 'AnonymousType#2'	C:\Documents and Settings\pkimmel.SOFTCONCEPTS\Local Settings\Application Data\Temporary Projects\AnonymousTypeEquality\Program.cs	17	25	AnonymousTypeEquality
      //Console.WriteLine(audioBook == songBook2); 
      // Error 2 Operator '==' cannot be applied order of member declarators is different
      //Console.WriteLine(audioBook == audioBook1);
      Console.WriteLine(audioBook == songBook1);         //same class different objects
      Console.WriteLine(audioBook.Equals(songBook1));    //true - fields are initialized the same way
      Console.WriteLine(audioBook.Equals(songBook2));
      Console.WriteLine(songBook1.Equals(songBook2));
      Console.WriteLine(audioBook1.Equals(audioBook));
      Console.ReadLine();
    }
  }
}
