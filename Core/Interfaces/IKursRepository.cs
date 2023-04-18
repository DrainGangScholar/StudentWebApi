using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces
{
    public interface IKursRepository
    {
        public Task<Kurs> GetKursByID(int id);
        public Task<IReadOnlyList<Kurs>> GetKursevi();
        public Task AddKurs(Kurs kurs);
        public Task UpdateKurs(Kurs kurs);
        public Task RemoveKurs(Kurs kurs);
    }
}