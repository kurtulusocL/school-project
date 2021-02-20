using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.Entities.Models;
using SchoolProject.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private IStudentService _studentService;
        private ILessonService _lessonService;
        private ITeacherService _teacherService;
        public StudentsController(IStudentService studentService, ITeacherService teacherService, ILessonService lessonService)
        {
            _teacherService = teacherService;
            _lessonService = lessonService;
            _studentService = studentService;
        }

        [HttpGet]
        public IActionResult GetStudents()
        {
            var student = _studentService.GetStudentAllIncluding();
            return Ok(student);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var student = _studentService.GetStudentById(id);
            if (student != null)
            {
                return Ok(student);
            }
            return NotFound();
        }

        [HttpPost]        
        public IActionResult Create([FromBody] Student model)
        {
            //var lesson = _lessonService.GetLessonById(model.LessonId);
           //var teacher = _teacherService.GetTeacherById(model.TeacherId);
            var student = _studentService.CreateStudent(model);
            return CreatedAtAction("Get", new { id = model.Id }, model);
        }

        [HttpPut("{id}")]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([FromBody] Student model)
        {
            if (_studentService.GetStudentById(model.Id) != null)
            {
                return Ok(_studentService.UpdateStudent(model));
            }
            return NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (_studentService.GetStudentById(id)!=null)
            {
                _studentService.DeleteStudent(id);
                return Ok();
            }
            return NotFound();
        }
    }
}
