using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using Data;
namespace Data
{
    public class DataContext : DbContext, IStudentDbContext
    {
        
        public DataContext(DbContextOptions<DataContext> options): base(options)
        {

        }
    
    



        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
           builder.Entity<Student>().HasData (
            new Student { Id = 1, Name = "John Doe" },
            new Student { Id = 2, Name = "Jane Doe" }
           );

        }
    }
}