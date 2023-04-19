using Core.Entities;

namespace Core.Interfaces
{
    public interface IStudentRepository
    {
        Task<Student> GetStudentByID(int id);
        Task<IReadOnlyList<Student>> GetStudenti();
        Task UpdatePrezime(int id, string prezime);
        Task RemoveStudent(Student student);
        Task AddStudent(Student student);
    }
}