using XptoAPI.Models;

namespace XptoAPI.DTOs
{
    public class ServiceOrderInputModel
    {
        public int ServiceNumber { get; set; }
        public string? ServiceTitle { get; set; }
        public DateTime ServiceDate { get; set; }
        public double ServiceValue { get; set; }
        public ClientInputModel? Client { get; set; }
        public ServiceExecuterInputModel? ServiceExecuter { get; set; }
    }
}
