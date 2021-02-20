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
    public class TeachersController : ControllerBase
    {
        private ITeacherService _teacherService;
        private ILessonService _lessonService;
        public TeachersController(ITeacherService teacherService, ILessonService lessonService)
        {
            _teacherService = teacherService;
            _lessonService = lessonService;
        }

        [HttpGet]
        public IActionResult GetTeachers()
        {
            return Ok(_teacherService.GetTeacherAllIncluding());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            if (_teacherService.GetTeacherById(id) != null)
            {
                return Ok(_teacherService.GetTeacherById(id));
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult Create([FromBody] Teacher model)
        {
            var teacher = _teacherService.CreateTeacher(model);
            return CreatedAtAction("Get", new { id = model.Id }, model);
        }

        [HttpPut("{id}")]
        public IActionResult Edit([FromBody] Teacher model)
        {
            if (_teacherService.GetTeacherById(model.Id) != null)
            {
                return Ok(_teacherService.UpdateTeacher(model));
            }
            return NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (_teacherService.GetTeacherById(id) != null)
            {
                _teacherService.DeleteTeacher(id);
                return Ok();
            }
            return NotFound();
        }
    }
}
