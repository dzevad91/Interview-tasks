using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();
            try
            {
                using (var reader = new StreamReader(@"Sample.csv"))
                {

                    reader.ReadLine();
                    while (!reader.EndOfStream)
                    {

                        var line = reader.ReadLine();
                        var values = line.Split(';');
                        CultureInfo provider = CultureInfo.InvariantCulture;
                        var format = "dd/MM/yyyy";
                        DateTime birthDate;
                        var parseSuccess = DateTime.TryParseExact(values[2], format, provider, DateTimeStyles.None, out birthDate);
                        if (!parseSuccess)
                        {
                            format = "dd.MM.yyyy";
                            parseSuccess = DateTime.TryParseExact(values[2], format, provider, DateTimeStyles.None, out birthDate);
                        }
                        if (!parseSuccess)
                        {
                            Console.WriteLine($"unknown date time format: \"{values[2]}\"");
                        }
                        var today = DateTime.Today;

                        var age = today.Year - birthDate.Year;
                        if (birthDate > today.AddYears(-age)) age--;

                        people.Add(
                            new Person
                            {
                                FirstName = values[0],
                                LastName = values[1],
                                Age = age
                            });
                    }
                }
            }
            catch(DirectoryNotFoundException ex)
            {
                Console.WriteLine(@"Please place the file in the correct directory task2\ConsoleApp1\ConsoleApp1\bin\Debug  and run the application again");
            }

            catch (FileNotFoundException ex)
            {
                Console.WriteLine(@"Please place the file in the correct directory task2\ConsoleApp1\ConsoleApp1\bin\Debug and run the application again");
            }

            foreach (var person in people)
            {
                Console.WriteLine($"{person.FullName.PadRight(20)} | {person.Age.ToString().PadRight(3)}");
            }

            Console.ReadLine();



            using (TextWriter writer = new StreamWriter(@"result.csv", false, System.Text.Encoding.UTF8))
            {
                CsvWriter csv = new CsvWriter(writer);
                csv.Configuration.RegisterClassMap<MyClassMap>();
                foreach (Person person in people)
                {
                    csv.WriteField(person.FullName);
                    csv.WriteField(person.Age);
                    csv.NextRecord();
                }
            }

            Console.WriteLine(@"You can find the CSV output file in task2\ConsoleApp1\ConsoleApp1\bin\Debug");
            Console.ReadLine();

        }
    }
}
