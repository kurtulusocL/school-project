using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolProject.Entities.Models
{
    public class Lesson : BaseHome
    {
        public string Name { get; set; }

        public virtual ICollection<Teacher> Teachers { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}
