Imports System.ServiceModel
Imports System.Runtime.Serialization

' NOTE: If you change the class name "Service" here, you must also update the reference to "Service" in Web.config and in the associated .svc file.

<ServiceContract()> _
Public Interface IMyService
    <OperationContract()> _
    Function MyTask1(ByVal MyValue As String) As String
    <OperationContract()> _
    Function MyTask2(ByVal dcValue As DataContract1) As String
End Interface
Public Class Service
    Implements IMyService
    Public Function MyTask1(ByVal Myvalue As String) As String Implements IMyService.MyTask1
        Return "Hello: " & Myvalue
    End Function
    Public Function MyTask2(ByVal dcValue As DataContract1) As String Implements IMyService.MyTask2
        Return "Hello: " & dcValue.FirstName
    End Function
End Class
<DataContract()> _
Public Class DataContract1
    Private firstName_Renamed As String
    Private lastName_Renamed As String
    <DataMember()> _
    Public Property FirstName() As String
        Get
            Return firstName_Renamed
        End Get
        Set(ByVal value As String)
            firstName_Renamed = value
        End Set
    End Property
    <DataMember()> _
    Public Property LastName() As String
        Get
            Return lastName_Renamed
        End Get
        Set(ByVal value As String)
            lastName_Renamed = value
        End Set
    End Property
End Class
