namespace EfCoreTopics.Database.Models;

public class SpecialProduct
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public DateTime RegisteredDateTime { get; set; }

    public virtual ICollection<SpecialProductPrice>? SpecialProductPrices { get; set; }
}