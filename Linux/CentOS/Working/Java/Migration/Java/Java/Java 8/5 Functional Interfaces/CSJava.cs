using System;
using System.Collections.Generic;

delegate double FunctionalNumber();

class CSJava {
    public static void Main(String[] args) {
        FunctionalNumber number;

        number = () => 123.45D;
        Console.WriteLine("Number: " + number());
        
	number = () => (new Random()).Next() * 100;
        Console.WriteLine("Random Number: " + number()); 
         	
        List<int> lst = new List<int>() {555, 77, 3};        
	/*
        lst.Add(555);
	lst.Add(77);
        lst.Add(3);
	*/
	
        Console.WriteLine("Count");
	int count = 0;
	Console.WriteLine("var i");
	lst.ForEach(i => Console.Write("{0}\n", (count += 1))); //
	int counter = 0;
	Console.WriteLine("var _");
	lst.ForEach(_=> Console.Write("{0}\n", (counter += 1))); //
	
	Console.WriteLine("Sum");
	int sum = 0;
	Console.WriteLine("var n");
        lst.ForEach(n => Console.Write("{0}\n", (sum += n)));
	int summation = 0;	
 	Console.WriteLine("var _");
        lst.ForEach(_=> Console.Write("{0}\n", (summation += _))); //

	// A local variable named '_' cannot be declared in this scope because it would give a different meaning to '_', which is already used in a 'child' scope to denote something else
	// var _ = 100; 
	// Console.WriteLine(_); 
	
    }
}