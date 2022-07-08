namespace EfCoreTopicsObjects;

public struct PersonInStruct
{
    public PersonInStruct(string name, int age)
    {
        Name = name;
        Age = age;
    }
    public string Name { get; set; }
    public int Age { get; set; }
}