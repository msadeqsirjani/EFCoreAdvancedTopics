namespace EfCoreTopics.Database.Models.NonKeyModels;

public class CityWithProvince
{
    public int Id { get; set; }
    public string City { get; set; } = null!;
    public string Provice { get; set; } = null!;
}