using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using School.Models;
using School.Methods;

namespace School.Controllers
{
    public class GradeController : Controller
    {
        private readonly SchoolBD dbContext = new();

        public async Task<IActionResult> Index()
        {
            var grade = await GradeMethods.GetGradesAsync();
            return View(grade);
        }

        public async Task<ActionResult> Details(int id)
        {
            var grade = await GradeMethods.GetGradeIdAsync(new Grade { Id = id });
            return View(grade);
        }

        public ActionResult Create()
        {
            ViewBag.Error = "";
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Create(Grade grade)
        {
            int result = await GradeMethods.CreateAsync(grade);
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(grade);
            }
        }

        public async Task<ActionResult> Edit(int id)
        {
            var grade = await GradeMethods.GetGradeIdAsync(new Grade { Id = id });
            ViewBag.Error = "";
            return View(grade);
        }
        [HttpPost]
        public async Task<ActionResult> Edit(Grade grade)
        {
            var result = await GradeMethods.UpdateAsync(grade);
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(grade);
            }
        }

        public async Task<ActionResult> Delete(int id)
        {
            var grade = await GradeMethods.GetGradeIdAsync(new Grade { Id = id });
            ViewBag.Error = "";
            return View(grade);
        }
        [HttpPost]
        public async Task<ActionResult> Delete(int id, Grade pgrade)
        {
            var result = await GradeMethods.DeleteAsync(new Grade { Id = id });
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                var grade = await GradeMethods.GetGradeIdAsync(pgrade);
                if (grade == null)
                    grade = new Grade();
                return View(grade);
            }
        }

    }
}
