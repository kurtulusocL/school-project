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
    public class TeacherController : Controller
    {
        HttpClient client = new HttpClient();
        private ILessonService _lessonService;
        private ITeacherService _teacherService;
        public TeacherController(ILessonService lessonService, ITeacherService teacherService)
        {
            _lessonService = lessonService;
            _teacherService = teacherService;
        }        
        public IActionResult Index()
        {
            var responseMessage = client.GetAsync("http://localhost:60439/api/Teachers").Result;
            var teacher = _teacherService.GetTeacherAllIncluding();
            if (responseMessage.StatusCode == HttpStatusCode.OK)
            {
                teacher = JsonConvert.DeserializeObject<List<Teacher>>(responseMessage.Content.ReadAsStringAsync().Result);
            }
            return View(teacher);
        }
        
        public IActionResult Detail(int id)
        {
            var responseMessage = client.GetAsync($"http://localhost:60439/api/Teachers/{id}").Result;
            var teacher = _teacherService.GetTeacherById(id);
            if (responseMessage.StatusCode == HttpStatusCode.OK)
            {
               teacher = JsonConvert.DeserializeObject<Teacher>(responseMessage.Content.ReadAsStringAsync().Result);
                return View(teacher);
            }
            return NotFound();
        }

        public IActionResult Create()
        {
            ViewBag.Lessons =_lessonService.GetLessonAllIncluding();
            return View(new Teacher());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Teacher model)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
            var response = client.PostAsync("http://localhost:60439/api/Teachers", content).Result;
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
            var response = client.GetAsync($"http://localhost:60439/Teachers/{id}").Result;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var teacher = JsonConvert.DeserializeObject<Teacher>(response.Content.ReadAsStringAsync().Result);
                return View(teacher);
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Teacher model)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
            var response = client.PutAsync($"http://localhost:60439/api/Teachers/{model.Id}", content).Result;
            ModelState.AddModelError("", "Güncelleme işleme başarısız");
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            var response = client.DeleteAsync($"http://localhost:60439/api/Teachers/{id}").Result;

            return RedirectToAction(nameof(Index));
        }
    }
}
