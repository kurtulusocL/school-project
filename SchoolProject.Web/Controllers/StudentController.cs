using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SchoolProject.Entities.Models;
using SchoolProject.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Web.Controllers
{
    public class StudentController : Controller
    {
        HttpClient client = new HttpClient();
        private IStudentService _studentService;
        private ILessonService _lessonService;
        private ITeacherService _teacherService;        
        public StudentController(IStudentService studentService, ITeacherService teacherService, ILessonService lessonService)
        {
            _studentService = studentService;
            _teacherService = teacherService;
            _lessonService = lessonService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var responseMessage = client.GetAsync("http://localhost:60439/api/Students").Result;
            var student = _studentService.GetStudentAllIncluding();
            if (responseMessage.StatusCode == HttpStatusCode.OK)
            {
                student = JsonConvert.DeserializeObject<List<Student>>(responseMessage.Content.ReadAsStringAsync().Result);
            }
            return View(student);
        }

        public IActionResult Create()
        {
            ViewBag.Lessons = _lessonService.GetLessonAllIncluding();
            ViewBag.Teachers = _teacherService.GetTeacherAllIncluding();
            return View(new Student());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Student model)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
            var response = client.PostAsync("http://localhost:60439/api/Students", content).Result;
            if (response.StatusCode == HttpStatusCode.Created)
            {
                return RedirectToAction(nameof(Index));
            }
            ModelState.AddModelError("", "Ekleme işleme başarısız");
            return View();
        }

        public IActionResult Edit(int id)
        {
            ViewBag.Lessons = _lessonService.GetLessonAllIncluding();
            ViewBag.Teachers = _teacherService.GetTeacherAllIncluding();

            var response = client.GetAsync($"http://localhost:60439/Students/{id}").Result;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var lesson = JsonConvert.DeserializeObject<Student>(response.Content.ReadAsStringAsync().Result);
                return View(lesson);
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Student model)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
            var response = client.PutAsync($"http://localhost:60439/api/Students/{model.Id}", content).Result;
            ModelState.AddModelError("", "Güncelleme işleme başarısız");
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            var response = client.DeleteAsync($"http://localhost:60439/api/Students/{id}").Result;

            return RedirectToAction(nameof(Index));
        }
    }
}
