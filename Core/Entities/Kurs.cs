namespace Core.Entities
{
    public class Kurs : BaseEntity
    {
        public string Sifra { get; set; } = "";
        public string Ime { get; set; } = "";
        public string Opis { get; set; } = "";

        public List<StudentKurs> PohadjaniKursevi { get; set; } = new List<StudentKurs>();
    }
}