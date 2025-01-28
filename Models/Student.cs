using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using P01_StudentSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01_StudentSystem.Models
{
    internal class Student
    {
        public int? StudentId { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime RegisteredOn { get; set; }
        public DateOnly? Birthday { get; set; }
        public ICollection<StudentCourse> StudentCourses { get; set; } = new List<StudentCourse>();
        public ICollection<HomeworkSubmission> Homework { get; set; } = new List<HomeworkSubmission>();


    }
}
