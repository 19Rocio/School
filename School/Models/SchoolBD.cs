using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace School.Models
{
    public class SchoolBD : DbContext
    {
        public SchoolBD() { }
        public DbSet<Course> Course { get; set; }
        public DbSet<Grade> Grade { get; set; }
        public DbSet<CourseGrade> CourseGrade { get; set; }
        public DbSet<Student> Student { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(@"Data Source=DESKTOP-OFGK424\SQLEXPRESS;Initial Catalog=School;Integrated Security=True");
        }
    }
}
