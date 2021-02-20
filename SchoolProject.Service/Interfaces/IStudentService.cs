using SchoolProject.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolProject.Service.Interfaces
{
    public interface IStudentService
    {
        List<Student> GetStudentAllIncluding();
        Student GetStudentById(int id);
        Student CreateStudent(Student model);
        Student UpdateStudent(Student model);
        void DeleteStudent(int id);
    }
}
