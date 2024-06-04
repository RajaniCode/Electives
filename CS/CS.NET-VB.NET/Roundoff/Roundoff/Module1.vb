Module Module1

    Public Function Roundoff(ByVal nValue As Double, ByVal nDigits As Integer) As Double
        Roundoff = Int(nValue * (10 ^ nDigits) + 0.5) / (10 ^ nDigits)
    End Function

    Sub Main()
        Dim x As Double = 111.4
        x = Roundoff(x, 0)
        MsgBox(x)
    End Sub

End Module
