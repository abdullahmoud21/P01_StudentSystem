using Microsoft.EntityFrameworkCore;
using P01_StudentSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01_StudentSystem.Data
{
    internal class StudentSystemDBContext : DbContext
    {
        public DbSet<Course> Courses { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<HomeworkSubmission> HomeworkSubmissions { get; set; }
        public DbSet<Resource> Resources { get; set; }
        public DbSet<StudentCourse> StudentsCourse { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer("Data Source =ABDULLAH; Initial Catalog = StudentSystem; Integrated Security = True; TrustServerCertificate = True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<StudentCourse>().HasKey(p => new { p.StudentId, p.CourseId });
            modelBuilder.Entity<Student>().Property(s => s.Name).HasColumnType("nvarchar(100)");
            modelBuilder.Entity<Student>().Property(s => s.PhoneNumber).HasColumnType("varchar(10)").IsRequired(false);
            modelBuilder.Entity<Course>().Property(c => c.Name).HasColumnType("nvarchar(80)");
            modelBuilder.Entity<Course>().Property(c => c.Description).HasColumnType("nvarchar(max)").IsRequired(false);
            modelBuilder.Entity<Resource>().Property(r => r.Name).HasColumnType("nvarchar(50)");
            modelBuilder.Entity<Resource>().Property(r => r.Url).HasColumnType("nvarchar(200)");
            modelBuilder.Entity<HomeworkSubmission>().HasKey(p => p.HomeworkId);
            modelBuilder.Entity<StudentCourse>()
                .HasKey(sc => new { sc.StudentId, sc.CourseId });

            modelBuilder.Entity<StudentCourse>()
                .HasOne(sc => sc.Student)
                .WithMany(s => s.StudentCourses)
                .HasForeignKey(sc => sc.StudentId);

            modelBuilder.Entity<StudentCourse>()
                .HasOne(sc => sc.Course)
                .WithMany(c => c.StudentCourses)
                .HasForeignKey(sc => sc.CourseId);
        }
    }
}
