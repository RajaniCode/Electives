'Imports System
'Imports System.Collections.Generic
'Imports System.Linq
'Imports System.Text
'Imports System.Data.Linq
'Imports System.Xml.Linq
'Imports System.Data.Linq.Mapping

'Module Module1

'    Sub Main()

'      Dim northwind As Northwind = New Northwind
'      Dim customers As Table(Of Customer) = northwind.GetTable(Of Customer)()

'      Dim xmlLiteral = <Customers>
'        <%= From cust In customers _
'        Select <Customer CustomerID=<%= cust.CustomerID %>
'               CompanyName=<%= cust.CompanyName %>
'               ContactName=<%= cust.ContactName %>>
'        <Address><%= cust.Address %></Address>
'        <City><%= cust.City %></City>
'        <State><%= cust.Region %></State>
'        <ZipCode><%= cust.PostalCode %></ZipCode>
'        </Customer> %>
'      </Customers>


'      Console.WriteLine(xmlLiteral.ToString())
'      Console.ReadLine()


'    End Sub

'End Module

'  Public Class Northwind
'    Inherits DataContext

'    Private Shared ReadOnly connectionString As String = _
'      "Data Source=BUTLER;Initial Catalog=Northwind;Integrated Security=True"

'    Public Sub New()
'      MyBase.New(connectionString)
'    End Sub

'  End Class

'  <Table(Name:="Customers")> _
'  Public Class Customer

'    Private FCustomerID As String

'    <Column(IsPrimaryKey:=True)> _
'    Public Property CustomerID() As String
'      Get
'        Return FCustomerID
'      End Get
'      Set(ByVal value As String)
'        FCustomerID = value
'      End Set
'    End Property

'    Private FCompanyName As String

'    <Column()> _
'    Public Property CompanyName() As String
'      Get
'        Return FCompanyName
'      End Get
'      Set(ByVal value As String)
'        FCompanyName = value
'      End Set
'    End Property


'    <Column()> _
'    Public ContactName As String

'    <Column()> _
'    Public ContactTitle As String

'    <Column()> _
'    Public Address As String


'    <Column()> _
'    Public City As String

'    <Column()> _
'    Public Region As String

'    <Column()> _
'    Public PostalCode As String

'    <Column()> _
'    Public Country As String

'    <Column()> _
'    Public Phone As String

'    <Column()> _
'    Public Fax As String
'  End Class
