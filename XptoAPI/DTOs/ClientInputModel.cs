using System.ComponentModel.DataAnnotations;

namespace XptoAPI.DTOs
{
    public class ClientInputModel
    {
        [MaxLength(11)]
        [MinLength(11)]
        [Required]
        public string? Cpf { get; set; }
        [Required]
        [MaxLength(100)]
        public string? Name { get; set; }
    }
}
