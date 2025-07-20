using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace MvcWeb.Models;

[Table("reviews")]
public class Review
{
    [Key]
    public int Id { get; set; }

    [Required]
    [DisplayName("Product ID")]
    public int ProductId { get; set; }
    
    public Product? Product { get; set; }

    [Required, MaxLength(200)]
    [DisplayName("User ID")]
    public required string UserId { get; set; }

    [Range(1, 5)]
    public int Rating { get; set; }

    [Required, StringLength(200)]
    public string? ReviewComment { get; set; }

    public DateTime ReviewDate { get; set; } = DateTime.Now;
}
