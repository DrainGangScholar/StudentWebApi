using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly SWAContext _context;
        public StudentRepository(SWAContext context){
            _context=context;
        }
        public async Task<Student> GetStudentByID(int id)
        {
            return await _context.Studenti.FindAsync(id);
        }

        public async Task<IReadOnlyList<Student>> GetStudenti()
        {
            return await _context.Studenti.ToListAsync();
        }

        public async Task RemoveStudent(Student student)
        {
            _context.Studenti.Remove(student);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateStudent(Student student)
        {
            await _context.SaveChangesAsync();
        }//PROVERI
    }
}