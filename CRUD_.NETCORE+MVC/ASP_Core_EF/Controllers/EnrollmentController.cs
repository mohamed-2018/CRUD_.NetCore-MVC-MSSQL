using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ASP_Core_EF.Services;
using ASP_Core_EF.Models;
using Microsoft.EntityFrameworkCore;

namespace ASP_Core_EF.Controllers
{
    public class EnrollmentController : Controller
    {
        private IEnrollment _Enrollment;
        private readonly ICourse _Course;
        private readonly IStudent _Student;
        public EnrollmentController(IEnrollment _IEnrollment, ICourse _ICourse, IStudent _IStudent)
        {
            _Enrollment = _IEnrollment;
            _Course = _ICourse;
            _Student = _IStudent;
        }
        public IActionResult Index()
        {
            return View(_Enrollment.GetEnrollments);
        }
        [HttpGet]
        public IActionResult Create()
        {
            Enrollment models = new Enrollment();
           models.EnrollmentId = 0;
           ViewBag.courses = _Course.GetCourses;
           ViewBag.students = _Student.GetStudents;
            return View(models);
        }
        [HttpPost]
        public IActionResult Create(Enrollment model)
        {
            if (ModelState.IsValid)
            {
                _Enrollment.Add(model);
                return RedirectToAction("Index");
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
                Enrollment model = _Enrollment.GetEnrollment(Id);
                return View(model);

            }
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirm(int? Id)
        {
            _Enrollment.Remove(Id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Details(int? Id)
        {
            return View(_Enrollment.GetEnrollment(Id));

        }
        [HttpGet]
        public IActionResult Edit(int? Id)
        {
            Enrollment model = _Enrollment.GetEnrollment(Id);
            ViewBag.courses = _Course.GetCourses;
            ViewBag.students = _Student.GetStudents;
            return View(model);

        }
        [HttpPost]
        public IActionResult Edit(Enrollment model )
        {            
            if (ModelState.IsValid)
            {
               
                    _Enrollment.Edit(model);

                    return RedirectToAction("Index");
               
            }
            return View();

        }



    }
}