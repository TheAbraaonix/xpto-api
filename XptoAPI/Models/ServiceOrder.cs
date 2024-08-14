namespace XptoAPI.Models
{
    public class ServiceOrder
    {
        public Guid Id { get; set; }
        public int ServiceNumber { get; set; }
        public string? ServiceTitle { get; set; }
        public DateTime ServiceDate { get; set; }
        public double ServiceValue { get; set; }

        public Guid ClientId { get; set; }
        public Client? Client { get; set; }

        public Guid ServiceExecuterId { get; set; }
        public ServiceExecuter? ServiceExecuter { get; set; }
    }
}
