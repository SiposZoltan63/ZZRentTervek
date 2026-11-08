using System.ComponentModel.DataAnnotations;

namespace ZZRent.Models
{
    public class Sofor
    {
        [Key]
        public int id { get; set; }

        [Required]
        [StringLength(100)]
        public string nev { get; set; } = string.Empty;

        [StringLength(20)]
        public string? telefonszam { get; set; }
    }
}
