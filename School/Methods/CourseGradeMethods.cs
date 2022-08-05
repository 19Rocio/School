using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using School.Models;

namespace School.Methods
{
    public class CourseGradeMethods
    {
        public static async Task<int> CreateAsync(CourseGrade courseGrade)
        {
            int result = 0;
            using(var db = new SchoolBD())
            {
                db.Add(courseGrade);
                result = await db.SaveChangesAsync();
            }
            return result;
        }
        public static async Task<int> UpdateAsync (CourseGrade parameter)
        {
            int result = 0;
            using(var db = new SchoolBD())
            {
                CourseGrade courseGrade = await db.CourseGrade.FirstOrDefaultAsync(s => s.Id == parameter.Id);
                courseGrade.GradeId = parameter.GradeId;
                courseGrade.CourseId = parameter.CourseId;
                db.CourseGrade.Update(courseGrade);
                result = await db.SaveChangesAsync();
            }
            return result;
        }
        public static async Task<int> DeleteAsync(CourseGrade parameter)
        {
            int result = 0;
            using(var db = new SchoolBD())
            {
                CourseGrade courseGrade = await db.CourseGrade.FirstOrDefaultAsync(s => s.Id == parameter.Id);
                db.Remove(courseGrade);
                result = await db.SaveChangesAsync();
            }
            return result;
        }
        public static async Task<List<CourseGrade>> GetCourseGradesAsync()
        {
            List<CourseGrade> listcourseGrade = new List<CourseGrade>();
            using(var db = new SchoolBD())
            {
                listcourseGrade = await db.CourseGrade.ToListAsync();
            }
            return listcourseGrade;
        }
        public static async Task<CourseGrade> GetCourseGradeIdAsync(CourseGrade parameter)
        {
            var courseGrade = new CourseGrade();
            using(var db = new SchoolBD())
            {
                courseGrade = await db.CourseGrade.FirstOrDefaultAsync(s => s.Id == parameter.Id);
            }
            return courseGrade;
        }
    }
}
