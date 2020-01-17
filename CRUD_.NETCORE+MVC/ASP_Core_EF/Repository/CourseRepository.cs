using ASP_Core_EF.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP_Core_EF.Models;
using Microsoft.EntityFrameworkCore;

namespace ASP_Core_EF.Repository
{
    public class CourseRepository : ICourse
    {
        private DB_Context db;
        public CourseRepository(DB_Context _db)
        {
            db = _db;
        }
        public IEnumerable<Course> GetCourses => db.courses;

        public void Add(Course _Course)
        {
            if (_Course.CourseId == 0)
            {
                db.courses.Add(_Course);
                 db.SaveChanges();
            }
            else
            {
                var dbEntity = db.courses.Find(_Course.CourseId);
                dbEntity.CourseName = _Course.CourseName;
                dbEntity.Credits = _Course.Credits;
                db.SaveChanges();
            }
            
            
        }

        public Course GetCourse(int? Id)
        {
            return db.courses.Include(e => e.enrollments).ThenInclude(s =>s.students).SingleOrDefault(a => a.CourseId == Id);
        }

        public void Remove(int? Id)
        {
           Course dbEntity= db.courses.Find(Id); ;
            db.courses.Remove(dbEntity);
            db.SaveChanges();
        }
    }
}
