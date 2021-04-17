using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentInformationSystem.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string CourseName { get; set; }
        public List<Student> Students { get; set; }
    }
}
