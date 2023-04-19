using Core.Entities;

namespace Core.Interfaces
{
    public interface IStudentKursRepository
    {
        Task<StudentKurs> GetStudentKursByID(int id);
        Task<IReadOnlyList<StudentKurs>> GetStudentKursByStudentID(int id);
        Task<IReadOnlyList<StudentKurs>> GetStudentKursByKursID(int id);
        Task<int> AddStudentKurs(StudentKurs studentKurs);
        Task UpdateOcena(int id, int ocena);
        Task RemoveStudentKurs(StudentKurs studentKurs);
        Task RemoveStudentKursByStudentID(int id);
        Task RemoveStudentKursByKursID(int id);
        Task<IReadOnlyList<StudentKurs>> GetStudentKursevi();
    }
}