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
        public async Task<int> AddStudentKurs(StudentKurs studentKurs)
        {
            await _context.PohadjaniKursevi.AddAsync(studentKurs);
            return await _context.SaveChangesAsync();
        }

        public async Task<IReadOnlyList<StudentKurs>> GetStudentKursByStudentID(int id)
        {
            return await _context.PohadjaniKursevi.Where(p => p.Student.ID == id).ToListAsync();
        }


        public async Task<IReadOnlyList<StudentKurs>> GetStudentKursByKursID(int id)
        {
            return await _context.PohadjaniKursevi.Where(p => p.Kurs.ID == id).ToListAsync();
        }
        public async Task RemoveStudentKurs(StudentKurs studentKurs)
        {
            _context.PohadjaniKursevi.Remove(studentKurs);
            await _context.SaveChangesAsync();
        }
        public async Task RemoveStudentKursByKursID(int id)
        {
            var pohadjaniKursevi = await _context.PohadjaniKursevi.Where(p => p.Kurs.ID == id).ToListAsync();
            _context.PohadjaniKursevi.RemoveRange(pohadjaniKursevi);
            await _context.SaveChangesAsync();
        }
        public async Task RemoveStudentKursByStudentID(int id)
        {
            var pohadjaniKursevi = await _context.PohadjaniKursevi.Where(p => p.Student.ID == id).ToListAsync();
            _context.PohadjaniKursevi.RemoveRange(pohadjaniKursevi);
            await _context.SaveChangesAsync();
        }


        public async Task UpdateOcena(int id, int ocena)
        {
            var studentKurs = await _context.PohadjaniKursevi.FindAsync(id);

            if (studentKurs != null)
            {
                studentKurs.Ocena = ocena;
                _context.PohadjaniKursevi.Update(studentKurs);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<StudentKurs> GetStudentKursByID(int id)
        {
            return await _context.PohadjaniKursevi.FindAsync(id);
        }
        public async Task<IReadOnlyList<StudentKurs>> GetStudentKursevi()
        {
            return await _context.PohadjaniKursevi
                .Include(sk => sk.Student)
                .Include(sk => sk.Kurs)
                .ToListAsync();
        }

    }
}