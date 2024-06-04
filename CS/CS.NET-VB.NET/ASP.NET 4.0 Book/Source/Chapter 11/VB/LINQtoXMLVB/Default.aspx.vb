
Partial Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            Dim employees As XElement = XElement.Parse(
                "<employees>" & ControlChars.CrLf &
                "<employee>" & ControlChars.CrLf &
                "<ID>E001</ID>" & ControlChars.CrLf &
                "<name>Ram</name>" & ControlChars.CrLf &
                "<designation>Writer</designation>" & ControlChars.CrLf &
                "</employee>" & ControlChars.CrLf &
                "<employee>" & ControlChars.CrLf &
                "<ID>E002</ID>" & ControlChars.CrLf &
                "<name>Harry</name>" & ControlChars.CrLf &
                "<designation>Manager</designation>" & ControlChars.CrLf &
                "</employee>" & ControlChars.CrLf &
                "<employee>" & ControlChars.CrLf &
                "<ID>E003</ID>" & ControlChars.CrLf &
                "<name>Neha </name>" & ControlChars.CrLf &
                "<designation>Writer</designation>" & ControlChars.CrLf &
                "</employee>" & ControlChars.CrLf &
                "<employee>" & ControlChars.CrLf &
                "<ID>E004</ID>" & ControlChars.CrLf &
                "<name>Umar</name>" & ControlChars.CrLf &
                "<designation>Writer</designation>" & ControlChars.CrLf &
                "</employee>" & ControlChars.CrLf &
                "<employee>" & ControlChars.CrLf &
                "<ID>E005</ID>" & ControlChars.CrLf &
                "<name>Shivam</name>" & ControlChars.CrLf &
                "<designation>Writer</designation>" & ControlChars.CrLf &
                "</employee>" & ControlChars.CrLf &
                "<employee>" & ControlChars.CrLf &
                "<ID>E006</ID>" & ControlChars.CrLf &
                "<name>Frensesco</name>" & ControlChars.CrLf &
                "<designation>Manager</designation>" & ControlChars.CrLf &
                "</employee>" & ControlChars.CrLf &
                "<employee>" & ControlChars.CrLf &
                "<ID>E007</ID>" & ControlChars.CrLf &
                "<name>Peter</name>" & ControlChars.CrLf &
                "<designation>Manager</designation>" & ControlChars.CrLf &
                "</employee>" & ControlChars.CrLf &
                "<employee>" & ControlChars.CrLf &
                "<ID>E008</ID>" & ControlChars.CrLf &
                "<name>Puja</name>" & ControlChars.CrLf &
                "<designation>Writer</designation>" & ControlChars.CrLf &
                "</employee>" & ControlChars.CrLf &
                "<employee>" & ControlChars.CrLf &
                "<ID>E009</ID>" & ControlChars.CrLf &
                "<name>Dheeraj</name>" & ControlChars.CrLf &
                "<designation>Writer</designation>" & ControlChars.CrLf &
                "</employee>" & ControlChars.CrLf & "<employee>" & ControlChars.CrLf &
                "<ID>E0010</ID>" & ControlChars.CrLf &
                "<name>Jaison</name>" & ControlChars.CrLf &
                "<designation>Manager</designation>" & ControlChars.CrLf &
                "</employee>" & ControlChars.CrLf &
                "</employees>" & ControlChars.CrLf & ControlChars.CrLf & "")
            ListBox1.Items.Add("The Employees who are Writers are:")
            Dim names = From employee In employees.Elements("employee") _
             Where CStr(employee.Element("designation")) = "Writer" _
             Select employee.Element("name")
            For Each Title1 In names
                ListBox1.Items.Add(Title1.Value)
            Next Title1
            ListBox1.Items.Add("The Employees who are Managers are:")
            Dim names1 = From employee In employees.Elements("employee") _
             Where CStr(employee.Element("designation")) = "Manager" _
             Select employee.Element("name")
            For Each Title1 In names1
                ListBox1.Items.Add(Title1.Value)
            Next Title1

        Catch ex As Exception
            ListBox1.Items.Add(ex.Message)
        End Try

    End Sub
End Class
