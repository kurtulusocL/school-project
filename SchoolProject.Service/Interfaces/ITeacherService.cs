using SchoolProject.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolProject.Service.Interfaces
{
    public interface ITeacherService
    {
        List<Teacher> GetTeacherAllIncluding();
        Teacher GetTeacherById(int id);
        Teacher CreateTeacher(Teacher model);
        Teacher UpdateTeacher(Teacher model);
        void DeleteTeacher(int id);
    }
}
