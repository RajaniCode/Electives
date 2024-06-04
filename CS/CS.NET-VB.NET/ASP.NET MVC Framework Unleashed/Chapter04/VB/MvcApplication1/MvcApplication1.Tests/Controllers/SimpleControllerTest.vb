Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports System.Web.Mvc
Imports System.IO

<TestClass()> _
Public Class SimpleControllerTest

    Private testContextInstance As TestContext

    Public Property TestContext() As TestContext
        Get
            Return testContextInstance
        End Get
        Set(ByVal value As TestContext)
            testContextInstance = value
        End Set
    End Property


    <TestMethod()> _
    Public Sub IndexView()
        ' Create simple view
        Dim viewPhysicalPath = testContextInstance.TestDir & "\..\..\MvcApplication1\Views\Simple\Index.simple"
        Dim indexView = New SimpleView(viewPhysicalPath)

        ' Create view context
        Dim context = New ViewContext()

        ' Create view data
        Dim viewData = New ViewDataDictionary()
        viewData("message") = "Hello World!"
        context.ViewData = viewData

        ' Render simple view
        Dim writer = New StringWriter()
        indexView.Render(context, writer)

        ' Assert
        StringAssert.Contains(writer.ToString(), "<h1>Hello World!</h1>")
    End Sub

End Class
