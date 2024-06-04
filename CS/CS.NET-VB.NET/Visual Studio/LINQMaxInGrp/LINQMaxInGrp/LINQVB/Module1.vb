Option Infer On
Module Module1

    Sub Main()
        Dim students As New List(Of Students)()
        students.Add(New Students() With {.StudentId = 1, .SubjectId = 1, .Marks = 8.0F})
        students.Add(New Students() With {.StudentId = 2, .SubjectId = 1, .Marks = 5.0F})
        students.Add(New Students() With {.StudentId = 3, .SubjectId = 1, .Marks = 7.0F})
        students.Add(New Students() With {.StudentId = 4, .SubjectId = 1, .Marks = 9.5F})
        students.Add(New Students() With {.StudentId = 1, .SubjectId = 2, .Marks = 9.0F})
        students.Add(New Students() With {.StudentId = 2, .SubjectId = 2, .Marks = 7.0F})
        students.Add(New Students() With {.StudentId = 3, .SubjectId = 2, .Marks = 4.0F})
        students.Add(New Students() With {.StudentId = 4, .SubjectId = 2, .Marks = 7.5F})

        Dim stud = _
         From s In students _
         Group s By Key = s.SubjectId Into Group _
     Let topp = Group.Max(Function(x) x.Marks) _
     Select New With {Key .Subject = Key, _
       Key .TopStudent = Group.First(Function(y) y.Marks = topp).StudentId, _
       Key .MaximumMarks = topp}

        For Each student In stud
            Console.WriteLine("In SubjectID {0}, Student with StudentId {1} got {2}", _
                              student.Subject, student.TopStudent, student.MaximumMarks)
        Next student
        Console.ReadLine()
    End Sub

End Module

Class Students
    Private privateStudentId As Integer
    Public Property StudentId() As Integer
        Get
            Return privateStudentId
        End Get
        Set(ByVal value As Integer)
            privateStudentId = value
        End Set
    End Property
    Private privateSubjectId As Integer
    Public Property SubjectId() As Integer
        Get
            Return privateSubjectId
        End Get
        Set(ByVal value As Integer)
            privateSubjectId = value
        End Set
    End Property
    Private privateMarks As Single
    Public Property Marks() As Single
        Get
            Return privateMarks
        End Get
        Set(ByVal value As Single)
            privateMarks = value
        End Set
    End Property
End Class
