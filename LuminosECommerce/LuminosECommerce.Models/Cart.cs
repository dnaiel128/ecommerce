using System.ComponentModel.DataAnnotations.Schema;

namespace LuminosECommerce.Models
{
    public class Cart : IEntityBase
    {
        public int Id { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        public User? User { get; set; }

        [ForeignKey("Item")]
        public int ItemId { get; set; }
        public Item? Item { get; set; }
    }
}