using System.ComponentModel.DataAnnotations.Schema;

namespace Lab3_OOP.Models
{
    public class Klempner
    {
        public int Id { get; set; }
        public int INN { get; set; }
        public int Gehalt { get; set; }
        public int MenschID { get; set; }
        [ForeignKey("MenschID")]
        public Human Mensch { get; set; }
    }
}
