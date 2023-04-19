using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.BaseEntities
{
    public abstract class BaseKurs
    {
        [Key]
        public int ID { get; set; }
        public string Sifra { get; set; }
        public string Ime { get; set; }
        public string Opis { get; set; }
        [JsonIgnore]
        public List<StudentKurs> PohadjaniKursevi { get; set; } = new List<StudentKurs>();

    }
}