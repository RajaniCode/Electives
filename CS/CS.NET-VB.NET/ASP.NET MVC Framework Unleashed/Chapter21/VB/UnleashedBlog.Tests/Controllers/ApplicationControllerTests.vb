Imports Microsoft.VisualStudio.TestTools.UnitTesting

<TestClass()> _
Public Class ApplicationControllerTests
    Private _controllerFactory As ControllerFactory
    Private _applicationController As ApplicationController

    <TestInitialize()> _
    Public Sub Initialize()
        _controllerFactory = New ControllerFactory()
        _applicationController = _controllerFactory.GetApplicationController()
    End Sub

    ''' <summary>
    ''' Verifies that ArchiveInfo (used by the ArchiveMenu) gets into view data
    ''' </summary>
    <TestMethod()> _
    Public Sub AddsArchiveInfoToViewData()
        ' Assert
        Assert.IsInstanceOfType(_applicationController.ViewData("ArchiveInfo"), GetType(IList(Of ArchiveInfo)))
    End Sub
End Class
