using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using School.Methods;
using School.Models;

namespace School.Controllers
{
    public class StudentController : Controller
    {
        public async Task<IActionResult> Index()
        {                        
            var student = await StudentMethods.GetStudentsAsync();
            return View(student);
        }
       
        public async Task<IActionResult> Details(int id)
        {
            var student = await StudentMethods.GetStudentIdAsync(id);
            return View(student);
        }

        public IActionResult Create()
        {
            ViewBag.Error = "";
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Student student)
        {
            var result = await StudentMethods.CreateAsync(student);
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(student);
            }
        }

        public async Task<IActionResult> Edit(int id)
        {
            var student = await StudentMethods.GetStudentIdAsync(id);
            ViewBag.Error = "";
            return View(student);
        }
        [HttpPost]
        public async Task<IActionResult> Edit (Student student)
        {
            var result = await StudentMethods.UpdateAsync(student);
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(student);
            }
        }

        public async Task<IActionResult> Delete (int id)
        {
            var student = await StudentMethods.GetStudentIdAsync(id);
            ViewBag.Error = "";
            return View(student);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id, Student pstudent) 
        {
            var result = await StudentMethods.DeleteAsync(id);
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                var student = await StudentMethods.GetStudentIdAsync(pstudent.Id);
                if (student == null)
                    student = new Student();
                return View(student);
            }
        }
    }
}
