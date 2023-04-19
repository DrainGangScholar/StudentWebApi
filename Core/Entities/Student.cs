using Core.BaseEntities;

namespace Core.Entities
{
    public class Student : BaseStudent
    {
        public List<StudentKurs> PohadjaniKursevi { get; set; } = new List<StudentKurs>();
    }
}