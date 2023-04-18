namespace Core.Entities
{
    public class StudentKurs : BaseEntity
    {
        public int Ocena { get; set; }
        public Student Student { get; set; }
        public Kurs Kurs { get; set; }
    }
}