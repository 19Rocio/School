using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using School.Models;

namespace School.Methods
{
    public class GradeMethods
    {
        public static async Task<int> CreateAsync(Grade grade)
        {
            int result = 0;
            using (var db = new SchoolBD())
            {
                db.Add(grade);
                result = await db.SaveChangesAsync();
            }
            return result;
        }
        public static async Task<int> UpdateAsync(Grade grade)
        {
            int result = 0;
            using (var db = new SchoolBD())
            {
                var grades = await db.Grade.FirstOrDefaultAsync(s => s.Id == grade.Id);
                grades.Name = grade.Name;
                db.Grade.Update(grades);
                result = await db.SaveChangesAsync();
            }
            return result;
        }
        public static async Task<int> DeleteAsync(Grade parameter)
        {
            int result = 0;
            using (var db = new SchoolBD())
            {
                var grade = await db.Grade.FirstOrDefaultAsync(s => s.Id == parameter.Id);
                db.Grade.Remove(grade);
                result = await db.SaveChangesAsync();
            }
            return result;
        }
        public static async Task<List<Grade>> GetGradesAsync()
        {
            List<Grade> listgrade = new List<Grade>();
            using(var db = new SchoolBD())
            {
                listgrade = await db.Grade.ToListAsync();
            }
            return listgrade;
        }
        public static async Task<Grade> GetGradeIdAsync(Grade parameter)
        {
            var grade = new Grade();
            using(var db = new SchoolBD())
            {
                grade = await db.Grade.FirstOrDefaultAsync(s => s.Id == parameter.Id);
            }
            return grade;
        }
    }
}
