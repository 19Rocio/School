using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using School.Models;

namespace School.Methods
{
    public class CourseMethods
    {
        public static async Task<int> CreateAsync(Course course) {
            int result = 0;

            using (var bd = new SchoolBD())
            {
                bd.Add(course);
                result = await bd.SaveChangesAsync();
            }
            return result;
        }
        public static async Task<int> UpdateAsync(Course pcourse)//pcourse = parametro
        {
            int result = 0;

            using (var bd = new SchoolBD())
            {
                var course = await bd.Course.FirstOrDefaultAsync(s => s.Id == pcourse.Id);
                course.Name = pcourse.Name;
                bd.Course.Update(course);
                result = await bd.SaveChangesAsync();
            }
            return result;
        }
        public static async Task<int> DeleteAsync(Course pcourse)
        {
            int result = 0;

            using (var bd = new SchoolBD())
            {
                var course = await bd.Course.FirstOrDefaultAsync(s => s.Id == pcourse.Id);
                bd.Course.Remove(course);
                result = await bd.SaveChangesAsync();
            }
            return result;
        }

        public static async Task<List<Course>> GetCoursesAsync()
        {
            var listcourse = new List<Course>();
            using (var bd = new SchoolBD())
            {
                listcourse = await bd.Course.ToListAsync();                
            }
            return listcourse;
        }

        public static async Task<Course> GetCourseIdAsync(Course pcourse)
        {
            var course = new Course();
            using (var bd = new SchoolBD())
            {
                course = await bd.Course.FirstOrDefaultAsync(s => s.Id == pcourse.Id);
                
            }
            return course;
        }
    }
}
