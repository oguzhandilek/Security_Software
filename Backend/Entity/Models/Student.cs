using Entity.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Models
{
    public class Student: BaseEntity
    {
        public string Firstname { get; set; } = string.Empty;
        public string Password {  get; set; }=string.Empty;
        public string? Lastname { get; set; } 
        public string? Email { get; set; } 
        public string Phone { get; set; } = string.Empty;
        public int? StudentNumber {  get; set; }
        public ICollection<Lesson>? Lessons { get; set; }
        public Student() { }
        public Student(string firstName, string phone, int studentNumber)
        {
            Firstname = firstName;
            Phone = phone;
            StudentNumber = studentNumber;
        }

    }
}
