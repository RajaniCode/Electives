Namespace ConversionAlgorithms
    Module Module1

        Sub Main(ByVal args As String())
            System.Console.WriteLine(clsConversion.DegreeToRadian(90.0R))
            System.Console.WriteLine(clsConversion.RadianToDegree(1))
            System.Console.WriteLine(clsConversion.RoundFloatToInt(124.3424F))
            System.Console.WriteLine(clsConversion.CelsiusToFahrenheit(1))
            System.Console.WriteLine(clsConversion.FahrenheitToCelsius(32))
            System.Console.WriteLine(clsConversion.StringToInt("23433"))
            System.Console.WriteLine(clsConversion.StringToBase64("I love dotnet"))
            System.Console.WriteLine(clsConversion.Base64ToString("SSBsb3ZlIGRvdG5ldA=="))
            System.Console.ReadLine()
        End Sub


    End Module
End Namespace
