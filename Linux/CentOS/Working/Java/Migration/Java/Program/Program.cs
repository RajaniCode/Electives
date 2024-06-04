using System;

class Program
{
    int Method(int i)
    {
	i = i * i;
	int j = i + 1;
	return j;
    }

    static void Main()
    {
	int n = 5;
	Program p = new Program();
	p.Method(n);
	Console.WriteLine("Number = " + n);
	Console.WriteLine("Fine");
    }
}