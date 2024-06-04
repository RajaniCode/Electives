using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Students> students = new List<Students>();
            students.Add(new Students() { StudentId = 1, SubjectId = 1, Marks = 8.0f });
            students.Add(new Students() { StudentId = 2, SubjectId = 1, Marks = 5.0f });
            students.Add(new Students() { StudentId = 3, SubjectId = 1, Marks = 7.0f });
            students.Add(new Students() { StudentId = 4, SubjectId = 1, Marks = 9.5f });
            students.Add(new Students() { StudentId = 1, SubjectId = 2, Marks = 9.0f });
            students.Add(new Students() { StudentId = 2, SubjectId = 2, Marks = 7.0f });
            students.Add(new Students() { StudentId = 3, SubjectId = 2, Marks = 4.0f });
            students.Add(new Students() { StudentId = 4, SubjectId = 2, Marks = 7.5f });

            var stud = from s in students
                    group s by s.SubjectId into stugrp
                      let topp = stugrp.Max(x => x.Marks)
                    select new
                    {
                        Subject = stugrp.Key,
                        TopStudent = stugrp.First(y => y.Marks == topp).StudentId,
                        MaximumMarks = topp
                    };

            foreach (var student in stud)
            {
                Console.WriteLine("In SubjectID {0}, Student with StudentId {1} got {2}",
                    student.Subject,
                    student.TopStudent,
                    student.MaximumMarks);
            }
            Console.ReadLine();
        }
    }

    class Students
    {
        public int StudentId {get; set;}
        public int SubjectId {get; set;}
        public float Marks { get; set; }
    }

        
}

