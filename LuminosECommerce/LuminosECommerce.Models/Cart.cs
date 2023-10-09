using System.ComponentModel.DataAnnotations.Schema;

namespace LuminosECommerce.Models
{
    public class Cart : IEntityBase
    {
        public int Id { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; } = null!;
        public List<CartItem>? CartItems { get; set; } = new List<CartItem>();
    }
}