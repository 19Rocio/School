using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using School.Models;
using School.Methods;

namespace School.Controllers
{
    public class CourseController : Controller
    {
        private SchoolBD bdcontext = new SchoolBD();
        // GET: CourseController
        public async Task<ActionResult> Index() 
        {
            var courses = await CourseMethods.GetCoursesAsync();
            return View(courses);
        }
        [HttpGet]
        public async Task<JsonResult> List()
        {
            List<Course> courses = await CourseMethods.GetCoursesAsync();

            return Json(new
            {
                data = courses.Select(c => new Course
                {
                    Id = c.Id,
                    Name = c.Name
                })
            });
        }
        
        // GET: CourseController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var course = await CourseMethods.GetCourseIdAsync(new Course { Id = id });
            return View(course);
        }
        [HttpGet]
        public async Task<JsonResult> GetCourseId(int id)
        {
            var result = await CourseMethods.GetCourseIdAsync(new Course { Id = id});
            return Json(
                new
                {
                    data = result
                });
        }
        // GET: CourseController/Create
        public ActionResult Create()
        {
            ViewBag.Error = "";
            return View();
        }
        
        // POST: CourseController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Course course)
        {
            int result = await CourseMethods.CreateAsync(course);
            try
            {
                
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(course);
                   
            }
        }
        
        public async Task<ActionResult> Edit(int id)
        {
            var course = await CourseMethods.GetCourseIdAsync(new Course { Id = id });
            ViewBag.Error = "";
            return View(course);
        }

        // POST: CourseController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Course course)
        {
            var result = await CourseMethods.UpdateAsync(course);
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(course);
            }
        }

        // GET: CourseController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var course = await CourseMethods.GetCourseIdAsync(new Course { Id = id });
            ViewBag.Error = "";
            return View(course);
        }

        // POST: CourseController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id,Course pcourse)
        {
            var result = await CourseMethods.DeleteAsync(new Course { Id = id});
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                var course = await CourseMethods.GetCourseIdAsync(pcourse);
                if (course == null)
                    course = new Course();
                return View(course);
            }
        }
        
    }
}
