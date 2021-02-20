using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolProject.Entities.Models
{
    public class Teacher : BaseHome
    {
        public string NameSurname { get; set; }
        public string Country { get; set; }
        public string Address { get; set; }

        public int LessonId { get; set; }
        public virtual Lesson Lesson { get; set; }

        public virtual ICollection<Student> Students { get; set; }
    }
}
