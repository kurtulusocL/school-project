using SchoolProject.Business.Interfaces;
using SchoolProject.Entities.Models;
using SchoolProject.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolProject.Service.Repositories
{
    public class TeacherService : ITeacherService
    {
        private readonly ITeacherRepository _teacherRepository;
        public TeacherService(ITeacherRepository teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }
        public Teacher CreateTeacher(Teacher model)
        {
           return _teacherRepository.Create(model);
        }

        public void DeleteTeacher(int id)
        {
            _teacherRepository.Delete(id);
        }

        public List<Teacher> GetTeacherAllIncluding()
        {
            return _teacherRepository.GetAllIncluding();
        }

        public Teacher GetTeacherById(int id)
        {
           return _teacherRepository.GetById(id);
        }

        public Teacher UpdateTeacher(Teacher model)
        {
           return _teacherRepository.Update(model);
        }
    }
}
