using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace LuminosECommerce.Models
{
    public class User : IEntityBase
    {
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string Username { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set;}
        [Required]
        [Column("IsAdmin")]
        public bool IsAdmin { get; set; }
        public List<Order>? Orders { get; set; } = new List<Order>();
        public List<UserReview>? UserReviews { get; set; } = new List<UserReview>();
        public List<Cart>? CartItems { get; set; }  = new List<Cart>();
    }
}
