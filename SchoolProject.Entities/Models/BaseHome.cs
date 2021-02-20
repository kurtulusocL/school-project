using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SchoolProject.Entities.Models
{
    public class BaseHome
    {
        [Key]
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public BaseHome()
        {
            CreatedDate = DateTime.Now.ToLocalTime();
        }
    }
}
