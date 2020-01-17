using ASP_Core_EF.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP_Core_EF.Models;
using Microsoft.EntityFrameworkCore;

namespace ASP_Core_EF.Repository
{
    public class StudentRepository : IStudent
    {
        private DB_Context db;
        public StudentRepository(DB_Context _db)
        {
            db = _db;
        }
        public IEnumerable<Student> GetStudents => db.students.Include(g => g.genders);

        public void Add(Student _Student)
        {
           
            if (_Student.StudentId == 0)
            {
                db.students.Add(_Student);
                db.SaveChanges();

            }
          
        }
        public void Edit(Student _Student)
        {
            if (_Student.StudentId != 0)
            {

                var dbEntity = db.students.Find(_Student.StudentId);
                dbEntity.FirstName = _Student.FirstName;
                dbEntity.LastName = _Student.LastName;
                dbEntity.DOB = _Student.DOB;
                dbEntity.RegistrationDate = _Student.RegistrationDate;
                dbEntity.GenderId = _Student.GenderId;
                dbEntity.Status = _Student.Status;
                db.SaveChanges();
            }
        }

      

        public Student GetStudent(int? Id)
        {
            Student dbEntity = db.students.Include(e =>e.enrollments)
                                          .ThenInclude(c => c.courses)
                                          .Include(g =>g.genders)
                                          .SingleOrDefault(m => m.StudentId==Id);
            return dbEntity;
        }

        public void Remove(int? Id)
        {
            Student dbEntity = db.students.Find(Id);
            db.students.Remove(dbEntity);
            db.SaveChanges();
        }
    }
}
