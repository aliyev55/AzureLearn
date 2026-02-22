using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace Data
{
    public interface IStudentDbContext
    {
         DbSet<Student> Students { get; set; }
        public void SaveChanges()
        {
            // Implementation of SaveChanges method
        }
    }
}