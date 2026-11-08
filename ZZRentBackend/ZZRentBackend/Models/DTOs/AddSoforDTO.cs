using System.ComponentModel.DataAnnotations;

namespace ZZRent.Models.DTOs
{
    public class AddSoforDTO
    {
        [Required]
        [StringLength(100)]
        public string nev { get; set; } = string.Empty;

        [StringLength(20)]
        public string? telefonszam { get; set; }
    }
}
