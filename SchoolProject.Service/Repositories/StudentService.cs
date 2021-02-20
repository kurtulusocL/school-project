using SchoolProject.Business.Interfaces;
using SchoolProject.Entities.Models;
using SchoolProject.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolProject.Service.Repositories
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
        public Student CreateStudent(Student model)
        {
           return _studentRepository.Create(model);
        }

        public void DeleteStudent(int id)
        {
            _studentRepository.Delete(id);
        }

        public List<Student> GetStudentAllIncluding()
        {
            return _studentRepository.GetAllIncluding();
        }

        public Student GetStudentById(int id)
        {
           return _studentRepository.GetById(id);
        }

        public Student UpdateStudent(Student model)
        {
           return _studentRepository.Update(model);
        }
    }
}
