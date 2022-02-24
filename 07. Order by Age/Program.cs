using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Order_by_Age
{
    class Person
    {
        public string Name { get; set; }
        public string Id { get; set; }
        public int Age { get; set; }
    }
    internal class Program
    {

        static void Main(string[] args)
        {
            List<Person> persons = new List<Person>();
            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] cmd = input.Split(' ');
                string name = cmd[0];
                string id = cmd[1];
                int age = int.Parse(cmd[2]);
                List<Person> existedPerson = persons.FindAll(person=>person.Id == id);
                if (existedPerson.Count > 0)
                {
                    foreach (Person person in persons)
                    {
                        if (person.Id == id)
                        {
                            person.Name = name;
                            person.Age = age;
                        }
                    }
                }
                else
                {
                    persons.Add(new Person { Name = name, Id = id, Age = age });
                }
            }
            List<Person> orderedPersons = persons.OrderBy(person => person.Age).ToList();
            foreach (Person item in orderedPersons)
            {
                Console.WriteLine($"{item.Name} with ID: {item.Id} is {item.Age} years old.");
            }
        }
    }
}
