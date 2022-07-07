namespace EfCoreTopics.Database.Models.Functions;

public class CustomerInformation
{
    public int CustomerId { get; set; }
    public string Firstname { get; set; } = null!;
    public string Lastname { get; set; } = null!;
}