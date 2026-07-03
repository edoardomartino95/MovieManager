using System;
using System.Collections.Generic;
using System.Text;

namespace MovieManager.DAL.Entities
{
    internal class Director
    {
        public int id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
       public DateOnly? BirthDate { get; set; }

        public string? Country { get; set; }

        public string? Biography { get; set; }

       public ICollection<Movie> Movies { get; set; } = new List<Movie>();

    }
}
