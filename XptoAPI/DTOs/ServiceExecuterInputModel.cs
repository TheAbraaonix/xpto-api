using System.ComponentModel.DataAnnotations;

namespace XptoAPI.DTOs
{
    public class ServiceExecuterInputModel
    {
        [MaxLength(14)]
        [MinLength(14)]
        [Required]
        public string? Cnpj { get; set; }
        [Required]
        [MaxLength(100)]
        public string? Name { get; set; }
    }
}
