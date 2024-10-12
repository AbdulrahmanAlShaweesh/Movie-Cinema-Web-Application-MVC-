using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaMovieWebApplication.Models.Entities
{
    public class ActorModel
    {
        public int Id {get; set;} 

        [Required]
        [Display(Name = "Profile Picture URL")]
        public string ProfileImage {get; set;} = string.Empty; 

        [Required] 
        [Display(Name = "Full Name")]
        [StringLength(100, ErrorMessage = "Name should be between 0-100 letters")]
        public string FullName {get; set;} = string.Empty; 

        [Required] 
        [Display(Name = "Biography")]
        public string bio {get; set;} = string.Empty;

        [Required]
        [Display(Name = "Awards")]
        public int AwardCount {get; set;}

        public ICollection<ActorMovieModel>? ActorsMovies {get; set;}
    }
}