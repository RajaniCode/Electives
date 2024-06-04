using System;
using System.Collections.Generic;
using System.Text;

namespace ConversionAlgorithms
{
    class clsConversion
    {
        // Convert Degree to Radian
        public static double DegreeToRadian(double degree)
        {
            return (Math.PI / 180) * degree;            
        }

        // Convert Radian To Degree
        public static double RadianToDegree(double radian)
        {            
            return (180 / Math.PI) * radian;
        }

        // Round Float to Integer
        public static int RoundFloatToInt(float f)
        {
            return ((int)Math.Round(f));
            
            // If you want to round to a fixed decimal place, say 3
            // return ((int)Math.Round(f,3));
        }

        // Celcius to Fahrenheit
        public static double CelsiusToFahrenheit(double cel)
        {
            return (((.9 / .5) * cel) + 32);
        }

        // Fahrenheit to Celcius
        public static double FahrenheitToCelsius(double farh)
        {
            return ((0.5 / 0.9) * (farh - 32));
        }

        // Convert String to Int
        public static int StringToInt(string str)
        {           
            return Int32.Parse(str);
        }

        // Convert String to Base64
        public static string StringToBase64(string str)
        {
            byte[] b = System.Text.Encoding.UTF8.GetBytes(str);
            string b64 = Convert.ToBase64String(b);
            return b64;
        }

        // Convert Base64string to string
        public static string Base64ToString(string b64)
        {
            byte[] b = Convert.FromBase64String(b64);
            return(System.Text.Encoding.UTF8.GetString(b));
        }        
    }
}
