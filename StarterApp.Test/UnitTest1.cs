using StarterApp.Database.Models;

namespace StarterApp.Test;

public class BasicModelTests
{
    // checks item data
    [Fact]
    public void Item_CanStoreTitleAndPrice()
    {
        var item = new Item
        {
            Title = "Drill",
            PricePerDay = 10
        };

        Assert.Equal("Drill", item.Title);
        Assert.Equal(10, item.PricePerDay);
    }


    // checks rental status
    [Fact]
    public void Rental_DefaultStatusCanBeRequested()
    {
        var rental = new Rental
        {
            Status = "Requested"
        };

        Assert.Equal("Requested", rental.Status);
    }
    // checks user email
    [Fact]
    public void User_CanStoreEmail()
    {
        var user = new User
        {
            Email = "test@example.com"
        };

        Assert.Equal("test@example.com", user.Email);
    }
}