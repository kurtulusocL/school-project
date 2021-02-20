using Microsoft.EntityFrameworkCore;
using SchoolProject.Business.Interfaces;
using SchoolProject.Data.Data;
using SchoolProject.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SchoolProject.Business.Repositories
{
    public class TeacherRepository : ITeacherRepository
    {
        ApplicationDbContext _db;
        public TeacherRepository(ApplicationDbContext db)
        {
            // _db = new ApplicationDbContext();
            _db = db;
        }
        public Teacher Create(Teacher model)
        {
            _db.Teachers.Add(model);
            _db.SaveChanges();
            return model;
        }

        public void Delete(int id)
        {
            var deleteTeacher = _db.Teachers.Find(id);
            _db.Teachers.Remove(deleteTeacher);
            _db.SaveChanges();
        }

        public List<Teacher> GetAllIncluding()
        {
            return _db.Teachers.Include("Students").Include("Lesson").ToList();
        }

        public Teacher GetById(int id)
        {
            return _db.Teachers.Find(id);
        }

        public Teacher Update(Teacher model)
        {
            _db.Teachers.Add(model);
            _db.SaveChanges();
            return model;
        }
    }
}
