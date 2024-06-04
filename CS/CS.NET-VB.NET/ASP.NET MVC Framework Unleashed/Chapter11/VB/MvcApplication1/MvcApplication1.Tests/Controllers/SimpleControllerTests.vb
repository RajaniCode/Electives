Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports System.Web.Mvc

<TestClass()> _
Public Class SimpleControllerTests

    <TestMethod()> _
    Public Sub TimeIsCached()
        ' Arrange
        Dim timeMethod = GetType(SimpleController).GetMethod("Time")
        Dim outputCacheAttributes = timeMethod.GetCustomAttributes(GetType(OutputCacheAttribute), True)

        ' Assert
        Assert.IsTrue(outputCacheAttributes.Length > 0)
        For Each att As OutputCacheAttribute In outputCacheAttributes
            Assert.AreEqual(5, att.Duration)
        Next att
    End Sub

End Class
