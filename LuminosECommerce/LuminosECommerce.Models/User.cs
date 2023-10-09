using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
namespace LuminosECommerce.Models
{
    public class User : IEntityBase
    {
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string? OwnerID { get; set; }
        public IdentityUser? Owner { get; set; }
        public Cart? Cart { get; set; }
        [Required]
        public bool IsAdmin { get;}
        public List<Order>? Orders { get; set; } = new List<Order>();
        public List<UserReview>? UserReviews { get; set; } = new List<UserReview>();
    }
}
