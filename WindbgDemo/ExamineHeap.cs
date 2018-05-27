using System;
using System.Collections.Generic;

namespace WindbgDemo
{
    public class ExamineHeap
    {
        private static HashSet<Person> persons = new HashSet<Person>(); 

        public void Run()
        {
            Person person = new Person { Name = new Name("First", "Last"), Age = 20 };
            persons.Add(person);

            Person otherPerson = new Person { Name = new Name("Other First", "Other Last"), Age = 25 };

            Console.WriteLine($"Added person to persons, now contains {persons.Count} elements.\n");
        }
    }
}
