using ASP_Core_EF.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP_Core_EF.Models;
using Microsoft.EntityFrameworkCore;

namespace ASP_Core_EF.Repository
{
    public class GenderRepository:IGender
    {
        private DB_Context db;
        public GenderRepository(DB_Context _db)
        {
            db = _db;
        }

        public IEnumerable<Gender> GetGenders => db.genders;

        public void Add(Gender _Gender)
        {
            if (_Gender.GenderId == 0)
            {
                db.genders.Add(_Gender);
                db.SaveChanges();

            }
           
        }
        public void Edit(Gender _Gender)
        {
            if (_Gender.GenderId != 0)
            {

                var dbEntity = db.genders.Find(_Gender.GenderId);
                dbEntity.GenderName = _Gender.GenderName;
              
                db.SaveChanges();
            }

        }
        public Gender GetGender(int? Id)
        {
            Gender dbEntity = db.genders.Include(s => s.students).SingleOrDefault(m => m.GenderId == Id);
            return dbEntity;
        }

        public void Remove(int? Id)
        {
            Gender dbEntity = db.genders.Find(Id);
             db.genders.Remove(dbEntity);
            
            db.SaveChanges();
        }
    }
}
