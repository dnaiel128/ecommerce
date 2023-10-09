using System.ComponentModel.DataAnnotations.Schema;

namespace LuminosECommerce.Models
{
    public class OrderedItem : IEntityBase
    {
        public int Id { get; set; }
        [ForeignKey("Item")]
        public int ItemId { get; set; }
        public Item? Item { get; set; }
        [ForeignKey("Order")]
        public int OrderId { get; set; }
        public Order? Order { get; set; }
    }
}