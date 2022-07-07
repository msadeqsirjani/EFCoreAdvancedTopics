namespace EfCoreTopics.Database.Models;

public class VGetAllCategory
{
    public string ParentProductCategoryName { get; set; } = null!;
    public string? ProductCategoryName { get; set; }
    public int? ProductCategoryId { get; set; }
}