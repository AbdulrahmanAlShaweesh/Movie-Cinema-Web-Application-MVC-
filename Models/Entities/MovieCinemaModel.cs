using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaMovieWebApplication.Models.Entities
{
    public class MovieCinemaModel
    {
        public int MovieId {get; set;} 
        public MovieModel? Movies {get; set;}

        public int CinemaId {get; set;}
        public CinemaModel? Cinema {get; set;}
    }
}