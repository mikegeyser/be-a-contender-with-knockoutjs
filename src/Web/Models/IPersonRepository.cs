using System;
using System.Collections.Generic;
namespace Web.Models
{
    public interface IPersonRepository
    {
        void Create(Person person);

        Person Find(int id);
        
        IEnumerable<Person> FindAll();
        
        void Save(Person person);
    }
}
