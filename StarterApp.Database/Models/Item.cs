using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StarterApp.Database.Models;

[Table("items")]
[PrimaryKey(nameof(Id))]
public class Item
{
    public int Id { get; set; }

    [Required]
    public string Title { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public decimal PricePerDay { get; set; }

    public string Category { get; set; } = string.Empty;

    public string LocationName { get; set; } = string.Empty;

    public double Latitude { get; set; }

    public double Longitude { get; set; }

    public bool IsAvailable { get; set; } = true;

    public int OwnerId { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    // links this item to the person who owns it
    public User? Owner { get; set; }
}