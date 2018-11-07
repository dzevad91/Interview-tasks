using CsvHelper.Configuration;

namespace ConsoleApp1
{
    public class Person 
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{FirstName} {LastName}";
        public int Age { get; set; }
    }

    

    public sealed class MyClassMap : ClassMap<Person>
    {
        public MyClassMap()
        {
            Map(person => person.FullName);
            Map(person => person.Age);
        }
    }
}
