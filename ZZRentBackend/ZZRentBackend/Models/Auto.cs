using System.ComponentModel.DataAnnotations;

namespace ZZRent.Models
{
    public class Auto
    {
        [Key]
        public int id { get; set; }

        [Required]
        [StringLength(50)]
        public string marka { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string modell { get; set; } = string.Empty;

        [Required]
        public int evjarat { get; set; }

        [Required]
        public int napi_ar { get; set; }

        [Required]
        [StringLength(30)]
        public string uzemanyag { get; set; } = string.Empty;

        [Required]
        [StringLength(30)]
        public string kategoria { get; set; } = string.Empty;

        [Required]
        public bool elerheto { get; set; }
    }
}
