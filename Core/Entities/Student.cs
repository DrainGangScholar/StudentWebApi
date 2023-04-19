using System.Text.Json.Serialization;
using Core.BaseEntities;

namespace Core.Entities
{
    public class Student : BaseStudent
    {
        [JsonIgnore]
        public List<StudentKurs> PohadjaniKursevi { get; set; } = new List<StudentKurs>();
    }
}