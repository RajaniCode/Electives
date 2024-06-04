' Inheritance - Constructor Overloading // Overridable // MyBase.New() 

Class Program
    Dim d As Date
    Private pwidth As Double
    Private pheight As Double
    Private pname As String

    Public Property width() As Double
        Get
            Return pwidth
        End Get
        Set(ByVal value As Double)
            pwidth = value
        End Set
    End Property

    Public Property height() As Double
        Get
            Return pheight
        End Get
        Set(ByVal value As Double)
            pheight = value
        End Set
    End Property

    Public Property name() As String
        Get
            Return pname
        End Get
        Set(ByVal value As String)
            pname = value
        End Set
    End Property

    Public Sub New()
    End Sub

    Public Sub New(ByVal w As Double, ByVal h As Double, ByVal n As String)
        width = w
        height = h
        name = n
    End Sub

    Public Sub New(ByVal d As Double, ByVal n As String)
        width = height = d
        name = n
    End Sub

    Public Sub New(ByVal TwoDObject As Program)
        ' NOTE 
        width = TwoDObject.width
        height = TwoDObject.height
        name = TwoDObject.name
    End Sub

    Public Overridable Function virtualmethodArea() As Double
        Console.WriteLine("virtualmethodArea() in TwoD, may be overridden")
        Return 0
    End Function

    Public Sub methodD()
        Console.WriteLine("width and height in TwoD are ")
        Console.WriteLine(width)
        Console.WriteLine(height)
    End Sub
End Class

Class Triangle
    Inherits Program
    Private style As String

    Public Sub New()
    End Sub

    Public Sub New(ByVal s As String, ByVal w As Double, ByVal h As Double)
        MyBase.New(w, h, "triangle")
        ' NOTE: "triangle" for string n (name = n) in base class 
        style = s
    End Sub

    Public Sub New(ByVal d As Double)
        MyBase.New(d, "triangle")
        ' NOTE: "triangle" for string n (name = n) in base class 
        style = "isosceles"
    End Sub

    Public Sub New(ByVal TriangleObject As Triangle)
        MyBase.New(TriangleObject)
        ' NOTE 
        ' NOTE 
        style = TriangleObject.style
    End Sub

    Public Overloads Overrides Function virtualmethodArea() As Double
        Console.WriteLine("virtualmethodArea() overridden in Triangle")
        Return (width * height) / 2
    End Function

    Public Sub methodStyle()
        Console.WriteLine(Chr(10) & "style in Triangle: {0}" & Chr(10) & "", style)
    End Sub
End Class

Class Rectangle
    Inherits Program

    Public Sub New()
    End Sub

    Public Sub New(ByVal w As Double, ByVal h As Double)
        MyBase.New(w, h, "rectangle")
        ' NOTE: "rectangle" for string n (name = n) in base class 
    End Sub

    Public Sub New(ByVal d As Double)
        MyBase.New(d, "rectangle")
        ' NOTE: "rectangle" for string n (name = n) in base class 
    End Sub

    Public Sub New(ByVal RectangleObject As Rectangle)
        MyBase.New(RectangleObject)
        ' NOTE 
    End Sub

    Public Overloads Overrides Function virtualmethodArea() As Double
        Console.WriteLine("virtualmethodArea() overridden in Rectangle")
        Return width * height
    End Function

    Public Function methodSquare() As Boolean
        If width = height Then
            Return True
        Else
            Return False
        End If
    End Function
End Class

Class MainClass
    Public Shared Sub Main()
        Dim TwoDObject As Program() = New Program(8) {}
        TwoDObject(0) = New Program(8, 12, "generic")
        ' like bc 
        TwoDObject(1) = New Program(10, "generic")
        ' like bc 
        TwoDObject(2) = New Program(New Program())
        ' NOTE // like bc 
        TwoDObject(3) = New Triangle("right", 8, 12)
        ' like bcr 
        TwoDObject(4) = New Triangle(10)
        ' like bcr 
        TwoDObject(5) = New Triangle(New Triangle())
        ' NOTE // like bcr 
        TwoDObject(6) = New Rectangle(8, 12)
        ' like bcr 
        TwoDObject(7) = New Rectangle(10)
        ' like bcr 
        TwoDObject(8) = New Rectangle(New Rectangle())
        ' NOTE // like bcr 
        For i As Integer = 0 To TwoDObject.Length - 1
            Console.WriteLine("Name: " + TwoDObject(i).name)
            Console.WriteLine("Area: ")
            Console.WriteLine(TwoDObject(i).virtualmethodArea())
            Console.WriteLine()
        Next
        Console.ReadLine()
    End Sub
End Class