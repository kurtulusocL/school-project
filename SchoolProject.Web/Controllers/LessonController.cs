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
    public class LessonController : Controller
    {
        HttpClient client = new HttpClient();
        private readonly ILessonService _lessonService;
        public LessonController(ILessonService lessonService)
        {
            _lessonService = lessonService;
        }       

        public IActionResult Index()
        {
            var responseMessage = client.GetAsync("http://localhost:60439/api/Lessons").Result;
            //List<Lesson> lessons = null;
            var lessons = _lessonService.GetLessonAllIncluding();
            if (responseMessage.StatusCode == HttpStatusCode.OK)
            {
                lessons = JsonConvert.DeserializeObject<List<Lesson>>(responseMessage.Content.ReadAsStringAsync().Result);
                
            }
            return View(lessons);
        }

        public IActionResult Create()
        {
            return View(new Lesson());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Lesson model)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
            var response = client.PostAsync("http://localhost:60439/api/Lessons", content).Result;
            if (response.StatusCode == HttpStatusCode.Created)
            {
                return RedirectToAction(nameof(Index));
            }
            ModelState.AddModelError("", "Ekleme işleme başarısız");
            return View();
        }

        public IActionResult Edit(int id)
        {
            var response = client.GetAsync($"http://localhost:60439/Lessons/{id}").Result;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var lesson = JsonConvert.DeserializeObject<Lesson>(response.Content.ReadAsStringAsync().Result);
                return View(lesson);
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Lesson model)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
            var response = client.PutAsync($"http://localhost:60439/api/Lessons/{model.Id}", content).Result;
            //if (response.StatusCode == HttpStatusCode.NoContent)
            //{

            //}
            ModelState.AddModelError("", "Güncelleme işleme başarısız");
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            var response = client.DeleteAsync($"http://localhost:60439/api/Lessons/{id}").Result;

            return RedirectToAction(nameof(Index));
        }
    }
}
