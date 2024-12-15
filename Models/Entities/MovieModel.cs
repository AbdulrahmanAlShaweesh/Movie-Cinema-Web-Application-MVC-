using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using CinemaMovieWebApplication.Data.Base;
using CinemaMovieWebApplication.Models.Enums;

namespace CinemaMovieWebApplication.Models.Entities
{
    public class MovieModel : IEntityBase
    {
        public int Id { get; set; }

        [Display(Name = "Movie Title")]
        public string Title { get; set; } = string.Empty;

        [Display(Name = "Description")]
        public string Description { get; set; } = string.Empty;

        [Display(Name = "Price")]
        public decimal Price { get; set; }

        [Display(Name = "Movie Profile URL")]
        public string MovieUrl { get; set; } = string.Empty;

        [Display(Name = "Movie Poster")]
        public string MoviePoster {get; set;} = string.Empty;

        [Display(Name = "Movie Rating")]
        public decimal Rating { get; set; }

        [Display(Name = "Movie Duration")]
        public int Duration { get; set; }

        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }

        [Display(Name = "Types")]
        public MovieTypes MovieTypes { get; set; }

        [Display(Name = "Language")]
        public string Language { get; set; } = string.Empty;

        [Display(Name = "Director Director")]
        public string Director { get; set; } = string.Empty;

        [Display(Name = "Production Company")]
        public string ProductionCompany { get; set; } = string.Empty;
        
        public int ProducerId {get; set;} 
        public ProducerModel? Producers {get; set;}

        public ICollection<ActorMovieModel> ActorsMovies {get; set;} = new List<ActorMovieModel>();
        public ICollection<MovieCinemaModel> MoviesCinemas {get; set;} = new List<MovieCinemaModel>();
    }
}