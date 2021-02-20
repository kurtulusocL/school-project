using SchoolProject.Business.Interfaces;
using SchoolProject.Entities.Models;
using SchoolProject.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolProject.Service.Repositories
{
    public class LessonService : ILessonService
    {
        private readonly ILessonRepository _lessonRepository;
        public LessonService(ILessonRepository lessonRepository)
        {
            _lessonRepository = lessonRepository;
        }
        public Lesson CreateLesson(Lesson model)
        {
            return _lessonRepository.Create(model);
        }

        public void DeleteLesson(int id)
        {
            _lessonRepository.Delete(id);
        }

        public List<Lesson> GetLessonAllIncluding()
        {
            return _lessonRepository.GetAllIncluding();
        }

        public Lesson GetLessonById(int id)
        {
           return _lessonRepository.GetById(id);
        }

        public Lesson UpdateLesson(Lesson model)
        {
            return _lessonRepository.Update(model);
        }
    }
}
