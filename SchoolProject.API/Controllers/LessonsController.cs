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
    public class LessonsController : ControllerBase
    {
        private ILessonService _lessonService;
        public LessonsController(ILessonService lessonService)
        {
            _lessonService = lessonService;
        }

        [HttpGet]
        public IActionResult GetLessons()
        {
            var lessonList = _lessonService.GetLessonAllIncluding().ToList();
            return Ok(lessonList);
        }

        [HttpGet("{id}")]
        public IActionResult GetLessonWithId(int id)
        {
            var lesson = _lessonService.GetLessonById(id);
            if (lesson != null)
            {
                return Ok(lesson);
            }
            return NotFound();
        }

        [HttpPost]        
        public IActionResult Create([FromBody] Lesson model)
        {
            var lesson = _lessonService.CreateLesson(model);
            return CreatedAtAction("Get", new { id = lesson.Id }, lesson);
        }

        [HttpPut("{id}")]
        public IActionResult Edit([FromBody] Lesson model)
        {
            if (_lessonService.GetLessonById(model.Id) != null)
            {
                return Ok(_lessonService.UpdateLesson(model));
            }
            return NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (_lessonService.GetLessonById(id) != null)
            {
                _lessonService.DeleteLesson(id);
                return Ok();
            }
            return NotFound();
        }
    }
}
