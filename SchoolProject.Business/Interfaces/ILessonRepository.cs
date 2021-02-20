using SchoolProject.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolProject.Business.Interfaces
{
    public interface ILessonRepository
    {
        List<Lesson> GetAllIncluding();
        Lesson GetById(int id);
        Lesson Create(Lesson model);
        Lesson Update(Lesson model);
        void Delete(int id);
    }
}
