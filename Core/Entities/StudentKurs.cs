namespace Core.Entities
{
    public class StudentKurs
    {
        public int ID { get; set; }
        public int Ocena { get; set; }
        public Student Student { get; set; }
        public Kurs Kurs { get; set; }
    }
}