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
    public class StudentRepository : IStudentRepository
    {
        ApplicationDbContext _db;
        public StudentRepository(ApplicationDbContext db)
        {
           // _db = new ApplicationDbContext();
            _db = db;
        }
        public Student Create(Student model)
        {
            _db.Students.Add(model);
            _db.SaveChanges();
            return model;
        }

        public void Delete(int id)
        {
           var deleteStudent =_db.Students.Find(id);
            _db.Students.Remove(deleteStudent);
            _db.SaveChanges();
        }

        public List<Student> GetAllIncluding()
        {
            return _db.Students.Include("Teacher").Include("Lesson").ToList();
        }

        public Student GetById(int id)
        {
           return _db.Students.Find(id);
        }

        public Student Update(Student model)
        {
            _db.Students.Add(model);
            _db.SaveChanges();
            return model;
        }
    }
}
