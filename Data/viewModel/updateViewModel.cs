using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaMovieWebApplication.Data.viewModel
{
    public class ActorViewModel
    {
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Bio { get; set; } = string.Empty;
        public int AwardCount { get; set; }
        public IFormFile? ProfileImage { get; set; }
        public string? ExistingImage { get; set; } // To hold the existing image path
    }

}