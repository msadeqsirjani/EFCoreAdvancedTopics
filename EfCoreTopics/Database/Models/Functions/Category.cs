namespace EfCoreTopics.Database.Models.Functions;

public class Category
{
    public int ProductCategoryId { get; set; }
    public string? ParentProductCategoryName { get; set; }
    public string ProductCategoryName { get; set; } = null!;
}