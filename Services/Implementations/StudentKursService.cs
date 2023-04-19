using Services.Interfaces;

namespace Services.Implementations
{
    public class StudentKursService : IStudentKursService
    {
        public decimal ProsecnaOcena(IReadOnlyList<int> ocene)
        {
            return (decimal)ocene.Average();
        }
    }
}