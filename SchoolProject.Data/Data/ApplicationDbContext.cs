using Microsoft.EntityFrameworkCore;
using SchoolProject.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolProject.Data.Data
{
    public class ApplicationDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=SchoolAPI;user Id=sa;Password=123");
            base.OnConfiguring(optionsBuilder);
        }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
    }
}
