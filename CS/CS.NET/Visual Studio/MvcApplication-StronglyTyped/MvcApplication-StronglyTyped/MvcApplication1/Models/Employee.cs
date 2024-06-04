using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MvcApplication1.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string GivenName { get; set; }
        public string Surname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool Permanent { get; set; }
        public double Salary { get; set; }
    }
}