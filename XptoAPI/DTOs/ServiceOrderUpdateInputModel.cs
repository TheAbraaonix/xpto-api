using System.ComponentModel.DataAnnotations;

namespace XptoAPI.DTOs
{
    public class ServiceOrderUpdateInputModel
    {
        [Required]
        [Range(1000, 9999)]
        public int ServiceNumber { get; set; }
        [Required]
        [MaxLength(255)]
        public string? ServiceTitle { get; set; }
        [Required]
        public DateTime ServiceDate { get; set; }
        [Required]
        [Range(1, 10000)]
        public double ServiceValue { get; set; }
        [Required]
        public ClientViewModel? Client { get; set; }
        [Required]
        public ServiceExecuterViewModel? ServiceExecuter { get; set; }
    }
}
