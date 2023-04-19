using Core.BaseEntities;

namespace Core.Entities
{
    public class Kurs : BaseKurs
    {
        public List<StudentKurs> PohadjaniKursevi { get; set; } = new List<StudentKurs>();
    }
}