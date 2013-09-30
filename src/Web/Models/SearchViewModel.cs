using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class SearchViewModel
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }

        public IEnumerable<Person> Results { get; set; }
    }
}