using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CinemaMovieWebApplication.Models.Entities;
using CinemaMovieWebApplication.Models.Enums;

namespace CinemaMovieWebApplication.Data.viewModel
{
    public class CreateMovieVeiwModel
    {
       
        

         
        public string Title { get; set; } = string.Empty;

        
        public string Description { get; set; } = string.Empty;

        
        public decimal Price { get; set; }

         
        public string MovieUrl { get; set; } = string.Empty;

         
        public IFormFile? MoviePoster {get; set;} 

        
        public decimal Rating { get; set; }

         
        public int Duration { get; set; }

         
        public DateTime ReleaseDate { get; set; }

         
        public MovieTypes MovieTypes { get; set; }

         
        public string Language { get; set; } = string.Empty;

         
        public string Director { get; set; } = string.Empty;

        
        public string ProductionCompany { get; set; } = string.Empty;
        
        public int ProducerId {get; set;} 
        public ProducerModel? Producers {get; set;}

        public string ExistingImage {get; set;} = string.Empty;
       
    }
}