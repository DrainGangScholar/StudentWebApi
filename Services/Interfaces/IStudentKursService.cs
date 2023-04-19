namespace Services.Interfaces
{
    public interface IStudentKursService
    {
        decimal ProsecnaOcena(IReadOnlyList<int> ocene);
    }
}