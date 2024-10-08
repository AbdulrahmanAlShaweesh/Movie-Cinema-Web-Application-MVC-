using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CinemaMovieWebApplication.Models.Enums;

namespace CinemaMovieWebApplication.Models.Entities
{
    public class MovieModel
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public decimal Price { get; set; }

        public string MovieUrl { get; set; } = string.Empty;

        public string MoviePoster {get; set;} = string.Empty;

        public decimal Rating { get; set; }

        public int Duration { get; set; }

        public DateTime ReleaseDate { get; set; }

        public MovieTypes MovieTypes { get; set; }

        public string Language { get; set; } = string.Empty;

        public string Director { get; set; } = string.Empty;

        public string ProductionCompany { get; set; } = string.Empty;
        
        public int ProducerId {get; set;} 
        public ProducerModel? Producers {get; set;}

        public ICollection<ActorMovieModel>? ActorsMovies {get; set;}
        public ICollection<MovieCinemaModel>? MoviesCinemas {get; set;}
    }
}