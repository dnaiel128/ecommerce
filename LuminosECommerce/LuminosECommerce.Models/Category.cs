using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LuminosECommerce.Models
{
    public class Category : IEntityBase
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string ImagePath { get; set; }
        public List<ItemCategory>? ItemCategories{ get; set; } = new List<ItemCategory>();

    }
}
