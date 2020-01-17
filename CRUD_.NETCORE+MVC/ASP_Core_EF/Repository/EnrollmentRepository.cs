using ASP_Core_EF.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP_Core_EF.Models;
using Microsoft.EntityFrameworkCore;

namespace ASP_Core_EF.Repository
{
    public class EnrollmentRepository : IEnrollment
    {
        private DB_Context db;
        public EnrollmentRepository(DB_Context _db)
        {
            db = _db;
           
           
        }
        public IEnumerable<Enrollment> GetEnrollments => db.enrollments.Include(S => S.students).Include(C => C.courses);

        public void Add(Enrollment _Enrollment)
        {
          
                if (_Enrollment.EnrollmentId==0)
                {
                    db.enrollments.Add(_Enrollment);
                    db.SaveChanges();
                   
                }
          

            
           

        }
      

        public void Edit(Enrollment _Enrollment)
        {
            if (_Enrollment.EnrollmentId != 0)
            {

                var dbEntity = db.enrollments.Find(_Enrollment.EnrollmentId);
                dbEntity.StudentId = _Enrollment.StudentId;
                dbEntity.CourseId = _Enrollment.CourseId;
                dbEntity.StartDate = _Enrollment.StartDate;
                dbEntity.EndDate = _Enrollment.EndDate;
                dbEntity.Grade = _Enrollment.Grade;
                db.SaveChanges();
            }

        }

        public Enrollment GetEnrollment(int? Id)
        {
            Enrollment dbEntity = db.enrollments.Include(s => s.students)
                                                .Include(c => c.courses)
                                                .SingleOrDefault(m => m.EnrollmentId == Id);
            return dbEntity;
        }

        public void Remove(int? Id)
        {
            Enrollment dbEntity = db.enrollments.Find(Id);
            db.enrollments.Remove(dbEntity);
            db.SaveChanges();


        }
        

    }
}
