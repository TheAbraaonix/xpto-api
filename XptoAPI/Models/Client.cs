using System.Text.Json.Serialization;

namespace XptoAPI.Models
{
    public class Client
    {
        public Guid Id { get; set; }
        public string? Cpf { get; set; }
        public string? Name { get; set; }

        [JsonIgnore]
        public ICollection<ServiceOrder> ServiceOrders { get; set; } = new List<ServiceOrder>();
    }
}
