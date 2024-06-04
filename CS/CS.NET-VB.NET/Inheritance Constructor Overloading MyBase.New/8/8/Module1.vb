' Inheritance - Constructor Overloading // MyBase.New() 

Imports System

Class BaseClass
    Private pwidth As Double
    ' private 
    Private pheight As Double
    ' private 
    ' Properties for width and height 

    Public Property width() As Double
        ' public 
        Get
            Return pwidth
        End Get
        Set(ByVal value As Double)
            pwidth = value
        End Set
    End Property

    Public Property height() As Double
        ' public 
        Get
            Return pheight
        End Get
        Set(ByVal value As Double)
            pheight = value
        End Set
    End Property

    Public Sub New()

        ' Note 
    End Sub

    Public Sub New(ByVal w As Double, ByVal h As Double)
        width = w
        height = h
    End Sub

    Public Sub methodD()
        Console.WriteLine(Chr(10) & "The width and height in BaseClass: ")
        Console.WriteLine(width)
        Console.WriteLine(height)
    End Sub
End Class

Class DerivedClass
    Inherits BaseClass
    Private style As String

    Public Sub New(ByVal s As String, ByVal w As Double, ByVal h As Double)
        width = w
        height = h
        style = s
    End Sub

    Public Function methodArea() As Double
        Return width * height / 2
    End Function

    Public Sub methodStyle()
        Console.WriteLine(Chr(10) & "The style of the triangle in DerivedClass is: ")
        Console.WriteLine(style)
    End Sub
End Class

Class Module1
    Public Shared Sub Main()
        Console.WriteLine(Chr(10) & "BaseClass constructor call: ")
        Dim bc As New BaseClass(5, 5)

        bc.methodD()
        ' BaseClass with BaseClass constructor argument 
        Console.WriteLine(Chr(10) & "DerivedClass constructor call: ")
        Dim bcr As BaseClass
        Dim dc As New DerivedClass("isosceles", 4, 4)
        bcr = dc

        bcr.methodD()
        ' BaseClass with DerivedClass constructor argument 
        dc.methodD()
        ' BaseClass with DerivedClass constructor argument 
        DirectCast(dc, BaseClass).methodD()
        ' BaseClass with DerivedClass constructor argument 
        dc.methodStyle()
        ' DerivedClass with DerivedClass constructor argument 
        Console.WriteLine("Area returned in DerivedClass = ")
        Console.WriteLine(dc.methodArea())
        ' DerivedClass with DerivedClass constructor argument 
        Console.ReadLine()
    End Sub
End Class
