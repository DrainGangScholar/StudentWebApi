using Core.Entities;

namespace Core.Interfaces
{
    public interface IStudentRepository
    {
        Task<Student> GetStudentByID(int id);
        Task<IReadOnlyList<Student>> GetStudenti();
        Task UpdateStudent(Student student);
        Task<Student> RemoveStudent(Student student);
        Task<Student> AddStudent(Student student);
    }
}