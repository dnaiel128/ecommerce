using System.ComponentModel.DataAnnotations.Schema;
namespace LuminosECommerce.Models.DTOs
{
    public class OrderDTO
    {            
        public int Id { get; set; }

        public decimal Total { get; set; }

        public DateTime OrderDate { get; set; }
        public List<OrderedDTO>? OrderedItems { get; set; } = new List<OrderedDTO>();
    }
}
