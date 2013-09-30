using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class PersonRepository : Web.Models.IPersonRepository
    {
        private readonly List<Person> _people;

        public static IPersonRepository Instance = new PersonRepository();

        public PersonRepository()
        {
            _people = new List<Person>();

            for (int i = 0; i < 10; i++)
            {
                _people.Add(new Person()
                {
                    Id = i,
                    Name = "Test " + i,
                    Surname = "Test " + i,
                    Email = "test" + i + "@test.test"
                });
            }
        }

        public IEnumerable<Person> FindAll()
        {
            return _people;
        }

        public Person Find(int id)
        {
            return _people.FirstOrDefault(x => x.Id == id);
        }

        public void Create(Person person)
        {
            person.Id = _people.Max(x => x.Id) + 1;
            _people.Add(person);
        }

        public void Save(Person person)
        {
            var originalPerson = Find(person.Id);

            originalPerson.Name = person.Name;
            originalPerson.Surname = person.Surname;
            originalPerson.Email = person.Email;
        }
    }
}