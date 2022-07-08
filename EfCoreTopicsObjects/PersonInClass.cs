namespace EfCoreTopicsObjects;

internal class PersonInClass
{
    public PersonInClass(string name, int age)
    {
        Name = name;
        Age = age;
    }

    public string Name { get; set; }
    public int Age { get; set; }
}