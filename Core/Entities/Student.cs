namespace Core.Entities
{
    public class Student : BaseEntity
    {
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Adresa { get; set; }
        public string Grad { get; set; }
        public string Drzava { get; set; }
        public DateTime DatumRodjenja { get; set; }
        public bool Pol { get; set; }
        public List<StudentKurs> PohadjaniKursevi { get; set; } = new List<StudentKurs>();
    }
}