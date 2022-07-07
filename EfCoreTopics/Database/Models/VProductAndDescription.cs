namespace EfCoreTopics.Database.Models;

/// <summary>
/// Product names and descriptions. Product descriptions are provided in multiple languages.
/// </summary>
public class VProductAndDescription
{
    public int ProductId { get; set; }
    public string Name { get; set; } = null!;
    public string ProductModel { get; set; } = null!;
    public string Culture { get; set; } = null!;
    public string Description { get; set; } = null!;
}