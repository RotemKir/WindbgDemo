using System;
using System.Linq;

namespace WindbgDemo
{
    public partial class ExamineObjects
    {

        public void Run()
        {
            var personA = new Person { Name = new Name("First A", "Last A"), Age = 30 };
            var personB = new Person { Name = new Name("First B", "Last B"), Age = 31 };
            var personC = new Person { Name = new Name("First C", "Last C"), Age = 36 };

            personA.Friends = new[] { personB, personC };
            personB.Friends = new[] { personA };

            PrintPersons(personA, personB, personC);
        }

        private void PrintPersons(params Person[] persons)
        {
            foreach (var person in persons)
            {
                PrintPerson(person);
            }
        }

        private void PrintPerson(Person person)
        {
            var friends = GetFriendNames(person);
            Console.WriteLine($"Person {person.Name.First} {person.Name.Last}, Age {person.Age} has friends: {friends }");
        }

        private string GetFriendNames(Person person)
        {
            var names = person.Friends.Select(x => x.Name.First);

            return string.Join(", ", names);
        }
    }
}
