using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SchoolDomainClasses
{
    public class Student
    {
        public Student()
        { 
        
        }
        
        public int StudentID { get; set; }
        public string StudentName { get; set; }
        public int Age { get; set; }
        public virtual Standard Standard { get; set; }
    }
}
