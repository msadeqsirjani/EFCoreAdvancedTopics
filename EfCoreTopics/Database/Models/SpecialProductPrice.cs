namespace EfCoreTopics.Database.Models;

public class SpecialProductPrice
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public decimal Price { get; set; }
    public DateTime RegisteredDate { get; set; }

    public SpecialProduct SpecialProduct { get; set; } = null!;
}