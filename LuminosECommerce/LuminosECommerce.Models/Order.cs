using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LuminosECommerce.Models
{
    public class Order : IEntityBase
    {
        public int Id { get; set; }
        [Required]
        public int Number { get; set; }
        [Required]
        public decimal Total { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        public User? User { get; set; }
        [DataType(DataType.Date)]
        public DateTime OrderDate { get; set; }
        public List<OrderedItem>? OrderedItems { get; set; } = new List<OrderedItem>();
    }
}
