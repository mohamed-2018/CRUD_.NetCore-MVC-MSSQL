using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ASP_Core_EF.Services;
using ASP_Core_EF.Models;

namespace ASP_Core_EF.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudent _Student;
        private readonly IGender _Gender;

        public StudentController(IStudent _IStudent,IGender _IGender)
        {
            _Student = _IStudent;
            _Gender = _IGender;
        }
        public IActionResult Index()
        {
            return View(_Student.GetStudents);
        }
        [HttpGet]
        public IActionResult Create()
        {
            Student models = new Student();
            models.StudentId = 0;

            ViewBag.Genders = _Gender.GetGenders;
            return View(models);
        }
        [HttpPost]
        public IActionResult Create(Student model)
        {
            if (ModelState.IsValid)
            {
                _Student.Add(model);
              return  RedirectToAction("Index");
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult Delete(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }
            else
            {
                Student model = _Student.GetStudent(Id);
                return View(model);
            }
        }

        [HttpPost,ActionName("Delete")]
        public  IActionResult DeleteConfirm(int ? Id)
        {
            _Student.Remove(Id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Details(int? Id)
        {
            return View(_Student.GetStudent(Id));
        }

        [HttpGet]
        public IActionResult Edit(int? Id)
        {
            var model = _Student.GetStudent(Id);
            ViewBag.Genders = _Gender.GetGenders;
            return View(model);
        }
        [HttpPost]
        public IActionResult Edit(Student model)
        {
            if (ModelState.IsValid)
            {

                _Student.Edit(model);

                return RedirectToAction("Index");

            }
            return View();

        }


    }
}