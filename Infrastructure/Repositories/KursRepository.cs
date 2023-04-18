using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class KursRepository : IKursRepository
    {
        private readonly SWAContext _context;
        public KursRepository(SWAContext context)
        {
            _context = context;
        }
        public async Task AddKurs(Kurs kurs)
        {
            await _context.Kursevi.AddAsync(kurs);
            await _context.SaveChangesAsync();
        }

        public async Task<Kurs> GetKursByID(int id)
        {
            return await _context.Kursevi.FindAsync(id);
        }

        public async Task<IReadOnlyList<Kurs>> GetKursevi()
        {
            return await _context.Kursevi.ToListAsync();
        }

        public async Task RemoveKurs(Kurs kurs)
        {
            _context.Kursevi.Remove(kurs);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateKurs(Kurs kurs)
        {
            await _context.SaveChangesAsync();
        }
    }
}