using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using InternationalStudents.Models;

namespace InternationalStudents.Database
{
    public partial class StudentContext : DbContext
    {
        public StudentContext(DbContextOptions<StudentContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Students> Students { get; set; }
        
    }
}
