Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports MvcFakes
Imports System.Text.RegularExpressions

<TestClass()> _
Public Class DataGridHelperTests

    Public Function CreateItems(ByVal count As Integer) As List(Of Product)
        Dim items = New List(Of Product)()
        For i = 0 To count - 1
            Dim newProduct = New Product()
            newProduct.Id = i
            newProduct.Name = String.Format("Product {0}", i)
            newProduct.Price = count - i
            items.Add(newProduct)
        Next i
        Return items
    End Function


    <TestMethod()> _
    Public Sub SecondPageNumberSelected()
        ' Arrange
        Dim items = CreateItems(5)
        Dim data = items.AsQueryable().ToPagedList(1, 2)

        ' Act
        Dim fakeHtmlHelper = New FakeHtmlHelper()
        Dim results = DataGridHelper.DataGrid(Of Product)(fakeHtmlHelper, data)

        ' Assert
        StringAssert.Contains(results, "<strong>2</strong>")

    End Sub


    <TestMethod()> _
    Public Sub CorrectNumberOfRows()
        ' Arrange
        Dim items = CreateItems(5)
        Dim data = items.AsQueryable().ToPagedList(1, 2)

        ' Act
        Dim fakeHtmlHelper = New FakeHtmlHelper()
        Dim results = DataGridHelper.DataGrid(Of Product)(fakeHtmlHelper, data)

        ' Assert (1 header row + 2 data rows + 1 pager row)
        Assert.AreEqual(4, Regex.Matches(results, "<tr>").Count)
    End Sub
End Class

Public Class Product
    Private _id As Integer
    Private _name As String
    Private _price As Decimal

    Public Property Id() As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
        End Set
    End Property

    Public Property Name() As String
        Get
            Return _name
        End Get
        Set(ByVal value As String)
            _name = value
        End Set
    End Property

    Public Property Price() As Decimal
        Get
            Return _price
        End Get
        Set(ByVal value As Decimal)
            _price = value
        End Set
    End Property
End Class
