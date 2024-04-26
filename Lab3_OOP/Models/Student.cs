using System.ComponentModel.DataAnnotations.Schema;

namespace Lab3_OOP.Models
{
    public class Student
    {
        public int Id { get; set; }
        public int Studak { get; set; }
        public int HumanID { get; set; }
        [ForeignKey("HumanID")]
        public Human Human { get; set; }
    }
}
