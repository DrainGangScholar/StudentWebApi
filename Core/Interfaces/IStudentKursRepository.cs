using Core.Entities;

namespace Core.Interfaces
{
    public interface IStudentKursRepository
    {
        Task<StudentKurs> GetStudentKursByID(int id);
        Task<IReadOnlyList<StudentKurs>> GetStudentKursByStudentID(int id);
        Task<IReadOnlyList<StudentKurs>> GetStudentKursByKursID(int id);
        void AddStudentKurs(StudentKurs studentKurs);
        void UpdateStudentKurs(StudentKurs studentKurs);
        void RemoveStudentKursByID(int id);
    }
}