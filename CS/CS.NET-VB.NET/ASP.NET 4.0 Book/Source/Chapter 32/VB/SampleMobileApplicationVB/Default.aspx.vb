Partial Class _Default
    Inherits System.Web.UI.MobileControls.MobilePage

    Protected Sub Command1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Command1.Click
        Dim Credit_Hr_1 As Integer = CType(TextBox1.Text, Integer)
        Dim Credit_Hr_2 As Integer = CType(TextBox2.Text, Integer)
        Dim Credit_Hr_3 As Integer = CType(TextBox3.Text, Integer)
        Dim Credit_Hr_4 As Integer = CType(TextBox4.Text, Integer)
        Dim Total_Crdt_Hr As Integer = Credit_Hr_1 + Credit_Hr_2 + Credit_Hr_3 +
        Credit_Hr_4

        Dim Grade1 As Char = CType(TextBox5.Text, Char)
        Dim Grade2 As Char = CType(TextBox6.Text, Char)
        Dim Grade3 As Char = CType(TextBox7.Text, Char)
        Dim Grade4 As Char = CType(TextBox8.Text, Char)
        Dim Grade_Value As Integer = 0
        Dim Temp_Grade_Value As Integer = 0

        If (Grade1 = "A") Then
            Temp_Grade_Value = Credit_Hr_1 * 4
        End If

        If (Grade1 = "B") Then
            Temp_Grade_Value = Credit_Hr_1 * 3
        End If

        If (Grade1 = "C") Then
            Temp_Grade_Value = Credit_Hr_1 * 2
        End If

        If (Grade1 = "D") Then
            Temp_Grade_Value = Credit_Hr_1 * 1
        End If
        If (Grade1 = "E") Then
            Temp_Grade_Value = Credit_Hr_1 * 0
        End If
        Grade_Value = Grade_Value + Temp_Grade_Value

        If (Grade2 = "A") Then
            Temp_Grade_Value = Credit_Hr_2 * 4
        End If

        If (Grade2 = "B") Then
            Temp_Grade_Value = Credit_Hr_2 * 3
        End If

        If (Grade2 = "C") Then
            Temp_Grade_Value = Credit_Hr_2 * 2
        End If

        If (Grade2 = "D") Then
            Temp_Grade_Value = Credit_Hr_2 * 1
        End If

        If (Grade2 = "E") Then
            Temp_Grade_Value = Credit_Hr_2 * 0
        End If

        Grade_Value = Grade_Value + Temp_Grade_Value

        If (Grade3 = "A") Then
            Temp_Grade_Value = Credit_Hr_3 * 4
        End If

        If (Grade3 = "B") Then
            Temp_Grade_Value = Credit_Hr_3 * 3
        End If

        If (Grade3 = "C") Then
            Temp_Grade_Value = Credit_Hr_3 * 2
        End If

        If (Grade3 = "D") Then
            Temp_Grade_Value = Credit_Hr_3 * 1
        End If

        If (Grade3 = "E") Then
            Temp_Grade_Value = Credit_Hr_3 * 0
        End If
        Grade_Value = Grade_Value + Temp_Grade_Value

        If (Grade4 = "A") Then
            Temp_Grade_Value = Credit_Hr_4 * 4
        End If

        If (Grade4 = "B") Then
            Temp_Grade_Value = Credit_Hr_4 * 3
        End If

        If (Grade4 = "C") Then
            Temp_Grade_Value = Credit_Hr_4 * 2
        End If
        If (Grade4 = "D") Then
            Temp_Grade_Value = Credit_Hr_4 * 1
        End If

        If (Grade4 = "E") Then
            Temp_Grade_Value = Credit_Hr_4 * 0
        End If
        Grade_Value = Grade_Value + Temp_Grade_Value

        Dim GPA As Decimal = Grade_Value / Total_Crdt_Hr

        Me.ActiveForm = Me.Form2

        Label1.Text = Grade_Value.ToString()

    End Sub

    Protected Sub Command2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Command2.Click
        Me.ActiveForm = Me.Form1
    End Sub
End Class
