﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LuminosECommerce.Models
{
    public class UserReview : IEntityBase
    {
        public int Id { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        public User? User { get; set; }
        [ForeignKey("Item")]
        public int ItemId { get; set; }
        public Item? Item { get; set; }
        [Required]
        public string Message { get; set; } = null!;
        public byte Stars { get; set; }
    }
}
