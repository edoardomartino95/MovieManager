using System;
using System.Collections.Generic;
using System.Text;
using MovieManager.BLL.Models.Interfaces;

namespace MovieManager.BLL.Models
{
    public class ReviewsModel : IModelWithId
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public MovieModel Movie { get; set; } = null!;
        public string ReviewerName { get; set; } = string.Empty;
        public int Score { get; set; }
        public string? Comment { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
