using EfCoreTopicsObjects;

var personInStructOne = new PersonInStruct("Sadeq", 22);
var personInStructTwo = new PersonInStruct("Sadeq", 22);

var personInStructEquality = personInStructOne.Equals(personInStructTwo);

Console.WriteLine($"Equality in struct: {personInStructEquality}");

var personInClassOne = new PersonInClass("Sadeq", 22);
var personInClassTwo = new PersonInClass("Sadeq", 22);

var personInClassEquality = personInClassOne.Equals(personInClassTwo);

Console.WriteLine($"Equality in class: {personInClassEquality}");

void ChangePersonAgeInStruct(PersonInStruct person) => person.Age = 30;
void ChangePersonAgeInClass(PersonInClass person) => person.Age = 30;

ChangePersonAgeInStruct(personInStructOne);
ChangePersonAgeInClass(personInClassOne);

Console.ReadLine();