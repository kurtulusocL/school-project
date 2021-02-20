using SchoolProject.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolProject.Business.Interfaces
{
    public interface IStudentRepository
    {
        List<Student> GetAllIncluding();
        Student GetById(int id);
        Student Create(Student model);
        Student Update(Student model);
        void Delete(int id);
    }
}
