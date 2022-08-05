using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using School.Models;

namespace School.Methods
{
    public class StudentMethods
    {
        public static async Task<int> CreateAsync(Student student)
        {
            int result = 0;
            using(var db = new SchoolBD())
            {
                db.Add(student);
                result = await db.SaveChangesAsync();
            }
            return result;
        }
        public static async Task<int> UpdateAsync(Student pstudent)
        {
            int result = 0;
            using (var db = new SchoolBD())
            {
                var student = await db.Student.FirstOrDefaultAsync(s => s.Id == pstudent.Id);
                student.StudentCode = pstudent.StudentCode;
                student.Name = pstudent.Name;
                student.BirthDate = pstudent.BirthDate;
                student.Gender = pstudent.Gender;
                student.GradeId = pstudent.GradeId;
                student.Comments = pstudent.Comments;
                db.Student.Update(student);
                result = await db.SaveChangesAsync();
            }
            return result;
        }
        public static async Task<int> DeleteAsync(int id)
        {
            int result = 0;
            using(var db = new SchoolBD())
            {
                Student student = await db.Student.FirstOrDefaultAsync(s => s.Id == id);
                db.Student.Remove(student);
                result = await db.SaveChangesAsync();
            }
            return result;
        }
        public static async Task<List<Student>> GetStudentsAsync()
        {
            List<Student> liststudent = new List<Student>();
            using (var db = new SchoolBD())
            {
                liststudent = await db.Student.ToListAsync();
            }
            return liststudent;
        }
        public static async Task<Student> GetStudentIdAsync(int id)
        {
            var student = new Student();
            using(var db = new SchoolBD())
            {
                student = await db.Student.FirstOrDefaultAsync(s => s.Id == id);
            }
            return student;
        }
    }
}
