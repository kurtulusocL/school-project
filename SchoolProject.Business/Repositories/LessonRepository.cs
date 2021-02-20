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
    public class LessonRepository : ILessonRepository
    {
        ApplicationDbContext _db;
        public LessonRepository(ApplicationDbContext db)
        {
            // _db = new ApplicationDbContext();
            _db = db;
        }
        public Lesson Create(Lesson model)
        {
            _db.Lessons.Add(model);
            _db.SaveChanges();
            return model;
        }

        public void Delete(int id)
        {
            var deleteLesson = GetById(id);
            _db.Lessons.Remove(deleteLesson);
            _db.SaveChanges();
        }

        public List<Lesson> GetAllIncluding()
        {
            var lessonList = _db.Lessons.Include("Teachers").Include("Students").ToList();
            return lessonList;
        }

        public Lesson GetById(int id)
        {
           return _db.Lessons.Find(id);
        }

        public Lesson Update(Lesson model)
        {
            _db.Lessons.Add(model);
            _db.SaveChanges();
            return model;
        }
    }
}
