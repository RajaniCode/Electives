'NOTE: If you change the class name "MyService" here, you must also update the reference to "MyService" in Web.config and in the associated .svc file.
Public Class MyService
    Implements IMyService

    'Public Sub DoWork() Implements IMyService.DoWork
    'End Sub

    'Public Sub GetByLastName() Implements IMyService.GetByLastName

    'End Sub

	Public Function GetByLastName(ByVal lastname As String) As System.Collections.Generic.List(Of Employee) Implements IMyService.GetByLastName
        Dim db As DataBindinginSilverlightVB.Web.MyClassDataContext = New MyClassDataContext()
        Dim data = From p In db.Employees Where p.LastName.StartsWith(lastname) Select p
        Return data.ToList
    End Function
End Class
