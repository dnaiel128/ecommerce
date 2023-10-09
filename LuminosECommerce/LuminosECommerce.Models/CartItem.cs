using System.ComponentModel.DataAnnotations.Schema;

namespace LuminosECommerce.Models
{
    public class CartItem : IEntityBase
    {
        public int Id { get; set; }
        [ForeignKey("Cart")]
        public int? CartId { get; set;}
        public Cart? Cart { get; set; }
        [ForeignKey("Item")]
        public int ItemId { get; set; }
        public Item? Item { get; set; }
    }
}