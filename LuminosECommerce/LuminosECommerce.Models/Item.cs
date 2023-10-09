using System.ComponentModel.DataAnnotations;

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
        public decimal Price { get; set; }
        [Required]
        public string ImageFolderPath { get; set; }
        public List<ItemCategory>? ItemCategories { get; set; } = new List<ItemCategory>();
        public List<CartItem>? CartItems { get; set; } = new List<CartItem>();
        public List<OrderedItem>? OrderedItems { get; set; } = new List<OrderedItem>();
        public List<UserReview>? UserReviews{ get; set; } = new List<UserReview>();
    }
}
