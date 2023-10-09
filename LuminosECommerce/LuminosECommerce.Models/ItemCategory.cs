using System.ComponentModel.DataAnnotations.Schema;

namespace LuminosECommerce.Models
{
    public class ItemCategory : IEntityBase 
    {
        public int Id { get; set; }
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
        [ForeignKey("Item")]
        public int ItemId { get; set; }
        public Item? Item { get; set; }
    }
}