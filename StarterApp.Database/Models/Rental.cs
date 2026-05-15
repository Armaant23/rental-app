using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace StarterApp.Database.Models;

[Table("rentals")]
[PrimaryKey(nameof(Id))]
public class Rental
{
    public int Id { get; set; }

    public int ItemId { get; set; }

    public int BorrowerId { get; set; }

    public int OwnerId { get; set; }

    public DateTime StartDate { get; set; } = DateTime.UtcNow;

    public DateTime EndDate { get; set; } = DateTime.UtcNow.AddDays(1);

    public decimal TotalPrice { get; set; }
    public string Status { get; set; } = "Requested";

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    // item being rented
    public Item? Item { get; set; }

    // user asking to rent
    public User? Borrower { get; set; }

    // user who owns the item
    public User? Owner { get; set; }
}