using Core.Entities;

namespace Core.Interfaces
{
    public interface IStudentRepository
    {
        Task<Student> GetStudentByID(int id);
        Task<IReadOnlyList<Student>> GetStudenti();
        void UpdateStudent(Student student);
        void RemoveStudentByID(int id);
    }
}