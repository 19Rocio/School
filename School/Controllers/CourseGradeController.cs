using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using School.Models;
using School.Methods;

namespace School.Controllers
{
    public class CourseGradeController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var coursegrade = await CourseGradeMethods.GetCourseGradesAsync();
            return View(coursegrade);
        }

        public async Task<ActionResult> Details(int id)
        {
            var coursegrade = await CourseGradeMethods.GetCourseGradeIdAsync(new CourseGrade { Id = id });
            return View(coursegrade);
        }

        public ActionResult Create()
        {
            ViewBag.Error = "";
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Create(CourseGrade courseGrade)
        {
            int result = await CourseGradeMethods.CreateAsync(courseGrade);
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(courseGrade);
            }
        }

        public async Task<ActionResult> Edit(int id)
        {
            var courseGrade = await CourseGradeMethods.GetCourseGradeIdAsync(new CourseGrade { Id = id });
            ViewBag.Error = "";
            return View(courseGrade);
        }
        [HttpPost]
        public async Task<ActionResult> Edit(CourseGrade courseGrade)
        {
            var result = await CourseGradeMethods.UpdateAsync(courseGrade);
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(courseGrade);
            }
        }

        public async Task<ActionResult> Delete (int id)
        {
            var courseGrade = await CourseGradeMethods.GetCourseGradeIdAsync(new CourseGrade { Id = id });
            ViewBag.Error = "";
            return View(courseGrade);
        }
        [HttpPost]
        public async Task<ActionResult> Delete(int id, CourseGrade parameter)
        {
            var result = await CourseGradeMethods.DeleteAsync(new CourseGrade { Id = id });
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                var courseGrade = await CourseGradeMethods.GetCourseGradeIdAsync(parameter);
                if (courseGrade == null)
                    courseGrade = new CourseGrade();
                return View(courseGrade);
            }
        }
    }
}
