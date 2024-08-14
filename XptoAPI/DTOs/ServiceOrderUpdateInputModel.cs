namespace XptoAPI.DTOs
{
    public class ServiceOrderUpdateInputModel
    {
        public int ServiceNumber { get; set; }
        public string? ServiceTitle { get; set; }
        public DateTime ServiceDate { get; set; }
        public double ServiceValue { get; set; }
        public Guid ClientId { get; set; }
        public Guid ServiceExecuterId { get; set; }
    }
}
