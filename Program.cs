using System;

namespace FilterbyAge
{

    public class Person
    {

        public int Age { get; set; }
        public string Name { get; set; }

    }

    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Person[] people = new Person[n];

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
                people[i] = new Person();
                people[i].Name = input[0];
                people[i].Age = int.Parse(input[1]);
            }

            string filter = Console.ReadLine();
            int filterAge = int.Parse(Console.ReadLine());

            Func<Person, bool> condition = GetAgeConditoion(filter, filterAge);

            Func<Person, string> formatter = GetFormatter(Console.ReadLine());
            
            PrintPeople(people, condition, formatter);
        }


        static Func<Person, bool> GetAgeConditoion(string filter, int filtredAge)
        {
            switch (filter)
            {
                case "younger":
                    return p => p.Age < filtredAge;
                case "older":
                    return p => p.Age >= filtredAge;
                default:
                    return null;

            }

        }

        static Func<Person, string> GetFormatter(string format)
        {
            switch (format)
            {
                case "name":
                    return p => $"{p.Name}";
                case "age":
                    return p => $"{p.Age}";
                case "name age":
                    return p => $"{p.Name} - {p.Age}";
                default:
                    return null;
            }
        }

        static void PrintPeople(Person[] people, Func<Person, bool> condition,
            Func<Person, string> formatter)
        {
            foreach (var person in people)
            {
                if (condition(person))
                {
                    Console.WriteLine(formatter(person));

                }
            }

        }
    }
}
