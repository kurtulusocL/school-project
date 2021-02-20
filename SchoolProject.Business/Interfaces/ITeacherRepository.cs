using SchoolProject.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolProject.Business.Interfaces
{
    public interface ITeacherRepository
    {
        List<Teacher> GetAllIncluding();
        Teacher GetById(int id);
        Teacher Create(Teacher model);
        Teacher Update(Teacher model);
        void Delete(int id);
    }
}
