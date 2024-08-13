namespace XptoAPI.Models
{
    public class ServiceExecuter
    {
        public Guid Id { get; set; }
        public string? Cpf { get; set; }
        public string? Name { get; set; }
        public ICollection<ServiceOrder> ServiceOrders { get; set; } = new List<ServiceOrder>();
    }
}
