namespace EfCoreTopics.Database.Models;

public class ProductPriceHistory
{
    public Guid Id { get; set; }
    public string ProductName { get; set; } = null!;
    public decimal ProductPrice { get; set; }
    public DateTime RegisteredDate { get; set; }

    public override string ToString()
    {
        return $"{ProductName} -- {ProductPrice}$ -- {RegisteredDate.ToShortDateString()}";
    }
}