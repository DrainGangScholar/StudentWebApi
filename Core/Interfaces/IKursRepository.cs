using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces
{
    public interface IKursRepository
    {
        Task<Kurs> GetKursByID(int id);
        Task<IReadOnlyList<Kurs>> GetKursevi();
        void AddKurs(Kurs kurs);
        void UpdateKurs(Kurs kurs);
        void RemoveKurs(Kurs kurs);
    }
}