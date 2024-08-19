using System.ComponentModel.DataAnnotations;
using XptoAPI.Models;

namespace XptoAPI.DTOs
{
    public class ServiceOrderInputModel
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
        public ClientInputModel? Client { get; set; }
        [Required]
        public ServiceExecuterInputModel? ServiceExecuter { get; set; }
    }
}
