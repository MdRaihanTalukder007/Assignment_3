using Assignment_3.Data.Entities;
using Assignment_3.Data.Repositories.Interfaces;
using Assignment_3.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Assignment_3.Controllers
{
    public class StudentsController : Controller
    {
        private readonly IStudentService _studentService;

        public StudentsController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        // Show students with Age > 18
        public IActionResult Index()
        {
            var students = _studentService.GetStudentsAboveAge(18);
            ViewBag.StudentCount = _studentService.GetStudentCountAboveAge(18);
            return View(students);
        }

        // Search by name
        public IActionResult Search(string query)
        {
            var result = _studentService.SearchStudents(query);
            ViewBag.StudentCount = _studentService.GetStudentCountAboveAge(18);
            return View("Index", result);
        }

        // Create form
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Student student)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _studentService.CreateStudent(student);
                    TempData["SuccessMsg"] = "Student added successfully.";
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Email", ex.Message);
            }
            return View(student);
        }

        public IActionResult Details(int id)
        {
            var student = _studentService.GetStudentById(id);
            if (student == null)
                return NotFound();
            return View(student);
        }

        public IActionResult Edit(int id)
        {
            var student = _studentService.GetStudentById(id);
            if (student == null)
                return NotFound();
            return View(student);
        }

        [HttpPost]
        public IActionResult Edit(Student student)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _studentService.UpdateStudent(student);
                    TempData["SuccessMsg"] = "Student updated successfully !";
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Email", ex.Message);
            }
            return View(student);
        }

        public IActionResult Delete(int id)
        {
            var student = _studentService.GetStudentById(id);
            if (student == null) return NotFound();
            return View(student);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _studentService.DeleteStudent(id);
            TempData["SuccessMsg"] = "Student deleted successfully !";
            return RedirectToAction("Index");
        }
    }
}
