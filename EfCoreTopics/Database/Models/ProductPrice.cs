using EfCoreTopics.Database.ValueObjects;

namespace EfCoreTopics.Database.Models;

public class ProductPrice
{
    public Guid Id { get; set; }
    public string ProductName { get; set; }
    public DateTime RegistrationDate { get; set; }
    public Money Money { get; set; }

    public ProductPrice(Guid id, string productName, DateTime registrationDate, Money money)
    {
        Id = id;
        ProductName = productName;
        RegistrationDate = registrationDate;
        Money = money;
    }

    private ProductPrice()
    {

    }
}