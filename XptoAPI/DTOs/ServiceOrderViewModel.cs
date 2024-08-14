namespace XptoAPI.DTOs
{
    public class ServiceOrderViewModel
    {
        public Guid Id { get; set; }
        public int ServiceNumber { get; set; }
        public string? ServiceTitle { get; set; }
        public DateTime ServiceDate { get; set; }
        public double ServiceValue { get; set; }
        public ClientViewModel? Client { get; set; }
        public ServiceExecuterViewModel? ServiceExecuter { get; set; }
    }
}
