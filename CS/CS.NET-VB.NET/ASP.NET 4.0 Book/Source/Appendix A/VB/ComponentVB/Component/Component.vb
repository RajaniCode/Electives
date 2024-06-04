Imports System.EnterpriseServices
Imports System.Reflection

<Assembly: ApplicationName("Component")> 
<Assembly: ApplicationAccessControl(False)> 
<Assembly: ApplicationActivation(ActivationOption.Server, SoapVRoot:="Component")> 
<Assembly: Description("Simple Serviced Component Sample")> 
<Assembly: AssemblyKeyFile("Component.snk")> 

Public Interface IMathOperation
    Function Add(ByVal num1 As Integer, ByVal num2 As Integer) As Integer
End Interface
<EventTrackingEnabled(True), Description("Simple Serviced Component Sample")> _
Public Class Component
    Inherits ServicedComponent
    Implements IMathOperation
    Public Sub New()
    End Sub
    Public Function Add(ByVal num1 As Integer, ByVal num2 As Integer) As Integer Implements IMathOperation.Add
        Return num1 + num2
    End Function
End Class
