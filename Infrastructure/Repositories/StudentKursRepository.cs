using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class StudentKursRepository : IStudentKursRepository
    {
        private readonly SWAContext _context;
        public StudentKursRepository(SWAContext context)
        {
            _context = context;
        }
        public async Task AddStudentKurs(StudentKurs studentKurs)
        {
            await _context.PohadjaniKursevi.AddAsync(studentKurs);
            await _context.SaveChangesAsync();
        }

        public async Task<IReadOnlyList<StudentKurs>> GetStudentKursByStudentID(int id)
        {
            return await _context.PohadjaniKursevi.Where(p=>p.Student.ID==id).ToListAsync();
        }
        public async Task<IReadOnlyList<StudentKurs>> GetStudentKursByKursID(int id)
        {
            return await _context.PohadjaniKursevi.Where(p=>p.Kurs.ID==id).ToListAsync();
        }
        public async Task RemoveStudentKurs(StudentKurs studentKurs)
        {
            _context.PohadjaniKursevi.Remove(studentKurs);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateOcena(StudentKurs studentKurs)
        {
            var _studentKurs = await _context.PohadjaniKursevi.FindAsync(studentKurs.ID);

            if (_studentKurs != null)
            {
                _studentKurs.Ocena=studentKurs.Ocena;
                _context.PohadjaniKursevi.Update(_studentKurs);
                await _context.SaveChangesAsync();
            }
        }//PROVERI

        public async Task<StudentKurs> GetStudentKursByID(int id)
        {
            return await _context.PohadjaniKursevi.FindAsync(id);
        }
    }
}