using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolProject.Entities.Models
{
    public class Student : BaseHome
    {
        public string NameSurname { get; set; }
        public DateTime Birthdate { get; set; }
        public string Address { get; set; }

        public int? TeacherId { get; set; }
        public int LessonId { get; set; }
        public virtual Teacher Teacher { get; set; }
        public virtual Lesson Lesson { get; set; }
    }
}
