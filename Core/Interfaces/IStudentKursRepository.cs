using Core.Entities;

namespace Core.Interfaces
{
    public interface IStudentKursRepository
    {
        Task<StudentKurs> GetStudentKursByID(int id);
        Task<IReadOnlyList<StudentKurs>> GetStudentKursByStudentID(int id);
        Task<IReadOnlyList<StudentKurs>> GetStudentKursByKursID(int id);
        Task AddStudentKurs(StudentKurs studentKurs);
        Task UpdateOcena(StudentKurs studentKurs);
        Task RemoveStudentKurs(StudentKurs studentKurs);
    }
}