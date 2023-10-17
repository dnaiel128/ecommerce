namespace LuminosECommerce.Models.DTOs;

using System.ComponentModel.DataAnnotations;

public class UserDTO
{
    [Required]
    public string Username { get; set; }

    [Required]
    public string Password { get; set; }
    [Required]
    public string FirstName { get; set; }
    [Required]
    public string LastName { get; set; }
    [Required]
    public bool IsAdmin { get; set; }
}