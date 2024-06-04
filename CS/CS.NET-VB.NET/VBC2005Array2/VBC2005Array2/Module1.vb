' Array // LOCAL 

' array assignment example: object() array = new object(){1}; // object() array = {1}; (ONLY AT DECLARATION) 

' array element assignment example: array(0) = 1; (no curly braces) 
' (array size should be set before element assignment (otherwise: System.NullReferenceException) AND the array index should be less than the size) 
' (array size re-defined can be changed ONLY using new) 

' Array and const array can be LOCAL (without access specifiers and member modifiers) (inside static/instance method) 
' readonly array (static/instance) cannot be assigned outside declaration and constructors BUT readonly array element assignment is POSSIBLE anywhere 

' Constants must be of an intrinsic or enumerated type, not a class, structure, type parameter, or array type


Imports System

Imports System.Collections

Class MainClass
    Public Shared Sub Main()
        ' int() a = { 5, 10, 15 }; // ONLY DURING DECLARATION 


        ' int() a; 

        ' a = new int() {5, 10, 15}; // a = new int(3) { 5, 10, 15 }; // INVALID: a = new int(4) { 5, 10, 15 }; // INVALID: a = new int(2) { 5, 10, 15 }; 

        ' INVALID: int y = 3; int() a; a = new int(y) { 5, 10, 15 }; 


        ' int() a; a = new int(3); // POSSIBLE without assignment // array index should be less than 3 

        ' int y = 3; int() a; a = new int(y); // POSSIBLE ONLY without assignment // POSSIBLE ONLY incase of LOCAL (inside static/instance method) // array index should be less than y 


        ' int() a = new int() { 5, 10, 15 }; // int() a = new int(3) { 5, 10, 15 }; // INVALID: int() a = new int(4) { 5, 10, 15 }; // INVALID: int() a = new int(2) { 5, 10, 15 }; 

        ' INVALID: int y = 3; int() a = new int(y) { 5, 10, 15 }; 


        ' int() a = new int(3); // POSSIBLE without assignment // array index should be less than 3 

        Dim y As Integer = 3
        Dim a As Integer() = New Integer(y - 1) {}
        ' POSSIBLE ONLY without assignment // POSSIBLE ONLY in case of LOCAL (inside static/instance method) AND INSIDE CONSTRUCTOR // array index should be less than y 
        a(0) = 5
        a(1) = 10
        a(2) = 15
        ' element assignment 

        ' INVALID: int() a; a = new int(); 

        ' INVALID: int() a = new int(); 


        'int x = 2; int()() b = new int(x)(); 
        Dim b As Integer()() = New Integer(1)() {}
        b(0) = New Integer(2) {}
        b(1) = New Integer(3) {}

        Dim c As Boolean()() = New Boolean(2)() {}
        c(0) = New Boolean(2) {}
        c(1) = New Boolean(1) {}
        c(2) = New Boolean(0) {}

        Dim d As Double(,) = New Double(1, 2) {}

        Dim e As String() = New String(2) {}

        Dim note As String

        Dim f As Char() = {"#"c, "1"c, "A"c}

        Console.WriteLine("a(0) = {0}, a(1) = {1}, a(2) = {2}", a(0), a(1), a(2))

        b(0)(0) = 1
        b(0)(1) = 2
        b(0)(2) = 3
        Console.WriteLine("b(0)(0) ={0}, b(0)(1) ={1}, b(0)(2) ={2}", b(0)(0), b(0)(1), b(0)(2))
        b(1)(0) = 1
        b(1)(1) = 2
        b(1)(2) = 3
        b(1)(3) = 4
        Console.WriteLine("b(1)(0) ={0}, b(1)(1) ={1}, b(1)(2) ={2}, b(1)(3) ={3}", b(1)(0), b(1)(1), b(1)(2), b(1)(3))

        c(0)(0) = True
        c(0)(1) = False
        c(0)(2) = True
        c(1)(1) = True
        c(2)(0) = False
        Console.WriteLine(" c(0)(0) ={0}, c(0)(1) = {1},c(0)(2) ={2},c(1)(1) ={3},c(2)(0) ={4}", c(0)(0), c(0)(1), c(0)(2), c(1)(1), c(2)(0))


        d(0, 0) = 7.147
        d(0, 1) = -7.157
        d(0, 2) = 2.8765
        d(1, 0) = -2.117
        d(1, 1) = 6.00138917
        d(1, 2) = -6.55
        Console.WriteLine("d(0, 0): {0} " & Chr(10) & "d(0, 1): {1} " & Chr(10) & "d(0, 2): {2} " & Chr(10) & "d(1, 0): {3} " & Chr(10) & "d(1, 1): {4} " & Chr(10) & "d(1, 2): {5} " & Chr(10) & "", d(0, 0), d(0, 1), d(0, 2), d(1, 0), d(1, 1), _
        d(1, 2))

        e(0) = "Joe1"
        e(1) = "Matt"
        e(2) = "Robert"
        Console.WriteLine("e(0): {0}, e(1): {1}, e(2): {2} " & Chr(10) & "", e(0), e(1), e(2))

        note = "note is not declared as an array; but it is declared simply a string, which means it is an array of characters"
        Console.WriteLine("note: {0} " & Chr(10) & "", note)
        Console.WriteLine("note(0): {0} " & Chr(10) & "", note(0))
        Console.WriteLine("The first space in the string is note(4): {0} " & Chr(10) & "", note(4))
        Console.WriteLine("note(49): {0} " & Chr(10) & "", note(49))
        Console.WriteLine("note(50): {0} " & Chr(10) & "", note(50))
        Console.WriteLine("note(108): {0} " & Chr(10) & "", note(108))
        Console.WriteLine("note(109): {0} " & Chr(10) & "", note(109))
        Console.WriteLine("The last character of the string is note(note.Length -1): {0} " & Chr(10) & "", note(note.Length - 1))
        Console.WriteLine("The length of the string is note.Length = {0} " & Chr(10) & "", note.Length)

        Console.WriteLine("f(0): {0}, f(1): {1}, f(2): {2} " & Chr(10) & "", f(0), f(1), f(2))

        'Arrays as Objects 
        Dim g As Double(,,) = New Double(1, 2, 4) {}
        Console.WriteLine("The length of the array is {0}. " & Chr(10) & "", g.Length)

        Dim h As Integer(,,) = New Integer(4, 9, 2) {}
        Console.WriteLine("The array has {0} dimensions. " & Chr(10) & "", h.Rank)

        'DateTime startDate = DateTime.Parse("06/23/2007"); 

        'DateTime startDate = DateTime.Parse("06/23/" + DateTime.Now.Year.ToString()); 

        'DateTime startDate = DateTime.Parse("06/" + DateTime.Now.Day.ToString() + "/" + DateTime.Now.Year.ToString()); 

        'DateTime startDate = DateTime.Parse(DateTime.Now.Month.ToString() + "/" + DateTime.Now.Day.ToString() + "/" + DateTime.Now.Year.ToString()); 

        'DateTime startDate = DateTime.Parse("00:00"); 

        'DateTime startDate = DateTime.Parse(DateTime.Now.Millisecond.ToString()); 

        'DateTime startDate = DateTime.Parse(DateTime.Now.Second.ToString()); 

        'DateTime startDate = DateTime.Parse(DateTime.Now.Minute.ToString()); 

        'DateTime startDate = DateTime.Parse(DateTime.Now.Hour.ToString()); 



        'DateTime startDate = DateTime.Parse(DateTime.Now.TimeOfDay.ToString()); 

        Dim startDate As DateTime = DateTime.Parse(DateTime.Now.Date.ToString())

        Dim dates As New ArrayList()
        For i As Integer = 1 To 10
            dates.Add(startDate.AddDays(i))
        Next

        Dim dateArray As DateTime() = New DateTime(dates.Count - 1) {}
        dates.CopyTo(dateArray)
        For j As Integer = 0 To dates.Count - 1
            Console.WriteLine(dateArray(j))
        Next

        MsgBox("Click OK")
    End Sub
End Class
