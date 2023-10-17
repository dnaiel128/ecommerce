using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LuminosECommerce.Models
{
    public class Item : IEntityBase
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        [Column(TypeName = "decimal(8, 2)")]
        public decimal Price { get; set; }
        [Required]
        public string ImageFolderPath { get; set; }
        public List<ItemCategory>? ItemCategories { get; set; } = new List<ItemCategory>();
        public List<Cart>? CartedItems { get; set; } = new List<Cart>();
        public List<OrderedItem>? OrderedItems { get; set; } = new List<OrderedItem>();
        public List<UserReview>? UserReviews{ get; set; } = new List<UserReview>();
    }
}
