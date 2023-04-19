using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Core.BaseEntities
{
    public abstract class BaseKurs
    {
        [Key]
        public int ID { get; set; }
        public string Sifra { get; set; }
        public string Ime { get; set; }
        public string Opis { get; set; }

    }
}