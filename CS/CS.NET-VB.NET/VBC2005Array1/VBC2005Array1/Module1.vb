' Array // data members 

' static fields (including static volatile and static readonly) 

' instance fields (including instance volatile and instance readonly) 


' volatile cannot be long, ulong, double and decimal 

' Array and const array can be LOCAL (without access specifiers and member modifiers) (inside static/instance method) 
' readonly array (static/instance) cannot be assigned outside declaration and constructors BUT readonly array element assignment is POSSIBLE anywhere 
' Constants must be of an intrinsic or enumerated type, not a class, structure, type parameter, or array type


Imports System

Class MainClass
    ' Note 
    Private Class [MyClass]
        Private size As Integer

        'Public Const c As String() = Nothing
        ' Constants must be of an intrinsic or enumerated type, not a class, structure, type parameter, or array type

        Public Shared s As String() = {"s1", "s2", "s3", "s4"}

        Public Shared sv As String()

        Public Shared ReadOnly sr As String()

        Public i As String() = New String() {"i1", "i2", "i3", "i4"}

        Public iv As String() = New String(3) {"iv1", "iv2", "iv3", "iv4"}

        Public ReadOnly ir As String() = New String(3) {}


        Shared Sub New()
            sr = New String() {"sr1", "sr2", "sr3", "sr4"}
        End Sub

        Public Sub New()
            size = 4
            sv = New String(size - 1) {}
            ir(0) = "ir1"
            ir(1) = "ir2"
            ir(2) = "ir3"
            ir(3) = "ir4"
        End Sub

        Public Sub New(ByVal sizep As Integer)
            sv = New String(sizep - 1) {}
            ir(0) = "newestir1"
            ir(1) = "newestir2"
            ir(2) = "newestir3"
            ir(3) = "newestir4"
        End Sub
    End Class

    Private Function instanceMethod() As String()
        'Const c1 As String() = Nothing
        ' Constants must be of an intrinsic or enumerated type, not a class, structure, type parameter, or array type
        Dim local1 As String() = New String() {"local11", "local12", "local13", "local14"}

        ' c1(0) = "c1"; // NOT POSSIBLE because it will throw System.NullReferenceException 

        local1 = New String() {"newerlocal11", "newerlocal12", "newerlocal13", "newerlocal14"}

        Return local1
    End Function

    Public Shared Sub Main()
        'Const c2 As String() = Nothing
        ' Constants must be of an intrinsic or enumerated type, not a class, structure, type parameter, or array type
        Dim local2 As String() = New String() {"local21", "local22", "local23", "local24"}


        Dim mc As New [MyClass]

        [MyClass].sv(0) = "sv1"

        [MyClass].sv(1) = "sv2"

        [MyClass].sv(2) = "sv3"

        [MyClass].sv(3) = "sv4"
        ' array index should be less than size 
        Console.WriteLine("" & Chr(10) & "# 1" & Chr(10) & "")
        For i As Integer = 0 To 3
            Console.WriteLine("" & Chr(10) & "MyClass.s({0}) = {1}, MyClass.sv({2}) = {3}, MyClass.sr({4}) = {5}, mc.i({6}) = {7}, mc.iv({8}) = {9}, mc.ir({10}) = {11}, local2({12}) = {13}" & Chr(10) & "", i, [MyClass].s(i), i, [MyClass].sv(i), i, _
            [MyClass].sr(i), i, mc.i(i), i, mc.iv(i), i, _
            mc.ir(i), i, local2(i))
        Next


        ' c2(0) = "c2"; // NOT POSSIBLE because it will throw System.NullReferenceException 

        local2 = New String() {"newerlocal21", "newerlocal22", "newerlocal23", "newerlocal24"}
        ' NOTE 

        ' MyClass.c = null; // NOT POSSIBLE because c is const 

        [MyClass].s = New String() {"newers1", "newers2", "newers3", "newers4"}

        ' MyClass.sr = new string() {"newersr1", "newersr2", "newersr3", "newersr4"}; // NoT POSSIBLE because sr is readonly BUT 


        [MyClass].sr(0) = "newersr1"
        ' POSSIBLE 
        [MyClass].sr(1) = "newersr2"
        ' POSSIBLE 
        [MyClass].sr(2) = "newersr3"
        ' POSSIBLE 
        [MyClass].sr(3) = "newersr4"
        ' POSSIBLE 

        mc.i = New String() {"neweri1", "neweri2", "neweri3", "neweri4"}

        mc.iv = New String() {"neweriv1", "neweriv2", "neweriv3", "neweriv4"}

        ' mc.ir = new string() {"newerir1", "newerir2", "newerir3", "newerir4"}; // NoT POSSIBLE because ir is readonly BUT 

        mc.ir(0) = "newerir1"
        ' POSSIBLE 
        mc.ir(1) = "newerir2"
        ' POSSIBLE 
        mc.ir(2) = "newerir3"
        ' POSSIBLE 
        mc.ir(3) = "newerir4"
        ' POSSIBLE 

        Console.WriteLine("" & Chr(10) & "# 2" & Chr(10) & "")
        For i As Integer = 0 To 3
            Console.WriteLine("" & Chr(10) & "MyClass.s({0}) = {1}, MyClass.sv({2}) = {3}, MyClass.sr({4}) = {5}, mc.i({6}) = {7}, mc.iv({8}) = {9}, mc.ir({10}) = {11}, local2({12}) = {13}" & Chr(10) & "", i, [MyClass].s(i), i, [MyClass].sv(i), i, _
            [MyClass].sr(i), i, mc.i(i), i, mc.iv(i), i, _
            mc.ir(i), i, local2(i))
        Next



        Dim mc1 As New [MyClass](4)

        [MyClass].sv(0) = "newestsv1"

        [MyClass].sv(1) = "newestsv2"

        [MyClass].sv(2) = "newestsv3"

        [MyClass].sv(3) = "newestsv4"
        ' array index should be less than size 
        Console.WriteLine("" & Chr(10) & "# 3" & Chr(10) & "")
        For i As Integer = 0 To 3
            Console.WriteLine("" & Chr(10) & "MyClass.s({0}) = {1}, MyClass.sv({2}) = {3}, MyClass.sr({4}) = {5}, mc1.i({6}) = {7}, mc1.iv({8}) = {9}, mc1.ir({10}) = {11}" & Chr(10) & "", i, [MyClass].s(i), i, [MyClass].sv(i), i, _
            [MyClass].sr(i), i, mc1.i(i), i, mc1.iv(i), i, _
            mc1.ir(i))
        Next



        Dim mac As New MainClass

        Dim args As String() = mac.instanceMethod()
        For i As Integer = 0 To 3
            Console.WriteLine(args(i))
        Next
        ' NOTE 
        ' NOTE 


        Dim size As Integer = 4

        Dim local3 As String() = New String(size - 1) {}
        ' POSSIBLE ONLY without assignment // POSSIBLE ONLY incase of LOCAL (inside static/instance method) AND INSIDE CONSTRUCTOR // array index should be less than size 
        local3(0) = "local31"

        local3(1) = "local32"

        local3(2) = "local33"

        local3(0) = "local34"

        local3 = New String() {"newlocal31", "newlocal32", "newlocal33", "newlocal34"}


        Dim local4 As String()

        local4 = New String(size - 1) {}
        ' POSSIBLE ONLY without assignment // POSSIBLE ONLY incase of LOCAL (inside static/instance method) AND INSIDE CONSTRUCTOR // array index should be less than size 
        local4(0) = "local41"

        local4(1) = "local42"

        local4(2) = "local43"

        local4(3) = "local44"

        local4 = New String() {"newlocal21", "newlocal22", "newlocal23", "newlocal24"}


        Dim array As String() = New String(3) {}
        ' POSSIBLE without assignment // array index should be less than 4 
        array(0) = "array1"

        array(1) = "array2"

        array(2) = "array3"

        array(3) = "array4"

        array = New String(4) {}

        array = New String() {"newarray1", "newarray2", "newarray3", "newarray4", "newarray5"}

        array = New String() {"newerarray1", "newerarray2", "newesrarray3"}

        MsgBox("Click OK")

    End Sub
End Class