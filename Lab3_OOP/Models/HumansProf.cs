using System.ComponentModel.DataAnnotations.Schema;

namespace Lab3_OOP.Models
{
    public class HumansProf
    {
        public int Id { get; set; }
        public int HumanID { get; set; }
        [ForeignKey("HumanID")]
        public Human Human { get; set; }
        public int ProfessionID { get; set; }
        [ForeignKey("ProfessionID")]
        public Profession Profession { get; set; }
    }
}
