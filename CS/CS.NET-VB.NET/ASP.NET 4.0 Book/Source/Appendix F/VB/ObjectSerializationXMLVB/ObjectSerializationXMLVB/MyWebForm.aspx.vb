Imports System
Imports System.Xml
Imports System.Xml.Serialization
Imports System.IO

Public Class MyWebForm
    Inherits System.Web.UI.Page
    <XmlRoot()> _
    Public Class Employee
        Private empID As Integer
        Private empName As String
        Private empSalary As Decimal
        <XmlElement()> _
        Public Property ID() As Integer
            Get
                Return empID
            End Get
            Set(ByVal value As Integer)
                empID = value
            End Set
        End Property
        <XmlElement()> _
        Public Property Name() As String
            Get
                Return empName
            End Get
            Set(ByVal value As String)
                empName = value
            End Set
        End Property
        <XmlElement()> _
        Public Property Salary() As Decimal
            Get
                Return empSalary
            End Get
            Set(ByVal value As Decimal)
                empSalary = value
            End Set
        End Property
    End Class
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub Button1_Click1(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click
        Dim XMLPath As String = "D:\employee.xml"
        Dim empdoc As New XmlDocument()
        Response.ContentType = "text/xml"
        Try
            empdoc.Load(XMLPath)
            Response.Write(empdoc.InnerXml)
            Response.End()
        Catch ex As XmlException
            Response.Write("XMLException:" & ex.Message)
        End Try
    End Sub

    Protected Sub Button2_Click1(ByVal sender As Object, ByVal e As EventArgs) Handles Button2.Click
        Dim emp As New Employee()
        emp.ID = 101
        emp.Name = "Steve"
        emp.Salary = 6000
        Dim tw As TextWriter = New StreamWriter("D:\employee.xml")
        Dim xs As New XmlSerializer(GetType(Employee))
        xs.Serialize(tw, emp)
        tw.Close()
        Dim fs As New FileStream("D:\employee.xml", FileMode.Open)
        Dim newXs As New XmlSerializer(GetType(Employee))
        Dim emp1 As Employee = CType(newXs.Deserialize(fs), Employee)
        If emp1 IsNot Nothing Then
            ListBox1.Items.Add(emp1.ID.ToString())
            ListBox1.Items.Add(emp1.Name.ToString())
            ListBox1.Items.Add(emp1.Salary.ToString())
        End If
        fs.Close()
    End Sub
End Class