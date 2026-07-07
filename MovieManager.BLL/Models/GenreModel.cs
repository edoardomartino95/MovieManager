using System;
using System.Collections.Generic;
using System.Text;
using MovieManager.BLL.Models.Interfaces;

namespace MovieManager.BLL.Models
{
    public class GenreModel : IModelWithId
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }

        public ICollection<MovieModel> Movies { get; set; } = new List<MovieModel>();
    }
}
