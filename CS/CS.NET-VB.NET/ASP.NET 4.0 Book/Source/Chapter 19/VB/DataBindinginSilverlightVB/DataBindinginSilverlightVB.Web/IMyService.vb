Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Runtime.Serialization
Imports System.ServiceModel
Imports System.Text


' NOTE: You can use the "Rename" command on the context menu to change the interface name "IMyService" in both code and config file together.
<ServiceContract()>
Public Interface IMyService

    '<OperationContract()>
    'Sub DoWork()
    <OperationContract()> _
    Function GetByLastName(ByVal lastname As String) As List(Of Employee)

End Interface