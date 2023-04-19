using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class SWAContext : DbContext
    {
        public SWAContext(DbContextOptions options) : base(options) { }
        public DbSet<Student> Studenti { get; set; }
        public DbSet<Kurs> Kursevi { get; set; }
        public DbSet<StudentKurs> PohadjaniKursevi { get; set; }
    }
}