Imports Microsoft.VisualBasic
Public Class Customer
    Private _CustID As Integer
    Public Property CustID() As Integer
        Get
            Return _CustID
        End Get
        Set(ByVal value As Integer)
            _CustID = value
        End Set
    End Property
    Private _CustName As String
    Public Property CustName() As String
        Get
            Return _CustName
        End Get
        Set(ByVal value As String)
            _CustName = value
        End Set
    End Property
    Private _CustAge As Integer
    Public Property CustAge() As Integer
        Get
            Return _CustAge
        End Get
        Set(ByVal value As Integer)
            _CustAge = value
        End Set
    End Property
	Public Sub New(ByVal intCustID As Integer, ByVal strCustName As String, ByVal intCustAge As Integer)
        _CustID = intCustID
        _CustName = strCustName
        _CustAge = intCustAge
    End Sub
End Class
