using SchoolProject.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolProject.Service.Interfaces
{
    public interface ILessonService
    {
        List<Lesson> GetLessonAllIncluding();
        Lesson GetLessonById(int id);
        Lesson CreateLesson(Lesson model);
        Lesson UpdateLesson(Lesson model);
        void DeleteLesson(int id);
    }
}
