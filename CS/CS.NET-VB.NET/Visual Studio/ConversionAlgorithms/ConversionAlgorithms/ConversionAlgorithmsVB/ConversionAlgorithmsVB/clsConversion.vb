Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Text

Namespace ConversionAlgorithms
    Friend Class clsConversion
        ' Convert Degree to Radian
        Public Shared Function DegreeToRadian(ByVal degree As Double) As Double
            Return (Math.PI / 180) * degree
        End Function

        ' Convert Radian To Degree
        Public Shared Function RadianToDegree(ByVal radian As Double) As Double
            Return (180 / Math.PI) * radian
        End Function

        ' Round Float to Integer
        Public Shared Function RoundFloatToInt(ByVal f As Single) As Integer
            Return (CInt(Fix(Math.Round(f))))

            ' If you want to round to a fixed decimal place, say 3
            ' return ((int)Math.Round(f,3));
        End Function

        ' Celcius to Fahrenheit
        Public Shared Function CelsiusToFahrenheit(ByVal cel As Double) As Double
            Return (((0.9 / 0.5) * cel) + 32)
        End Function

        ' Fahrenheit to Celcius
        Public Shared Function FahrenheitToCelsius(ByVal farh As Double) As Double
            Return ((0.5 / 0.9) * (farh - 32))
        End Function

        ' Convert String to Int
        Public Shared Function StringToInt(ByVal str As String) As Integer
            Return Int32.Parse(str)
        End Function

        ' Convert String to Base64
        Public Shared Function StringToBase64(ByVal str As String) As String
            Dim b As Byte() = System.Text.Encoding.UTF8.GetBytes(str)
            Dim b64 As String = Convert.ToBase64String(b)
            Return b64
        End Function

        ' Convert Base64string to string
        Public Shared Function Base64ToString(ByVal b64 As String) As String
            Dim b As Byte() = Convert.FromBase64String(b64)
            Return (System.Text.Encoding.UTF8.GetString(b))
        End Function
    End Class
End Namespace
