using System;
using System.Collections.Generic;
using System.Text;

namespace ConversionAlgorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine(clsConversion.DegreeToRadian(90d));
            System.Console.WriteLine(clsConversion.RadianToDegree(1));
            System.Console.WriteLine(clsConversion.RoundFloatToInt(124.3424f));
            System.Console.WriteLine(clsConversion.CelsiusToFahrenheit(1));
            System.Console.WriteLine(clsConversion.FahrenheitToCelsius(32));
            System.Console.WriteLine(clsConversion.StringToInt("23433"));
            System.Console.WriteLine(clsConversion.StringToBase64("I love dotnet"));
            System.Console.WriteLine(clsConversion.Base64ToString("SSBsb3ZlIGRvdG5ldA=="));            
            System.Console.ReadLine();
        }              
    }
}
