using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaMovieWebApplication.Models.Entities
{
    public class ActorMovieModel
    {
        // Navigation Property For Actor
        public int ActorId {get; set;}
        public ActorModel? Actors {get; set;}

        // Navigation Properity For Movie..
        public int MovieId {get; set;} 
        public MovieModel? Movies {get; set;
        }
    }
}