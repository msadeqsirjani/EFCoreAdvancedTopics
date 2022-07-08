namespace EfCoreTopics.Database.ValueObjects;

public class Money
{
    public decimal Value { get; set; }
    public MoneyType Unit { get; set; }

    public Money(decimal value, MoneyType unit)
    {
        Value = value;
        Unit = unit;
    }
}

public enum MoneyType
{
    Dollar,
    Euro
}