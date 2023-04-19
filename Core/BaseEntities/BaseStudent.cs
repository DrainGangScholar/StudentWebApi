using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Core.Entities;

namespace Core.BaseEntities
{
    public abstract class BaseStudent
    {
        [Key]
        public int ID { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Adresa { get; set; }
        public string Grad { get; set; }
        public string Drzava { get; set; }
        public DateTime DatumRodjenja { get; set; }
        public byte? Pol { get; set; } = 2;//0 musko, 1 zensko, bilo sta drugo je nebitno u sustini...
        [JsonIgnore]
        public List<StudentKurs> PohadjaniKursevi { get; set; } = new List<StudentKurs>();
    }
}