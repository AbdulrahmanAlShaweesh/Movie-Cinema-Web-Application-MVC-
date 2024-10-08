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
        public string ProfileImage {get; set;} = string.Empty; 

        [Required] 
        [StringLength(100, ErrorMessage = "Name should be between 0-100 letters")]
        public string FullName {get; set;} = string.Empty; 

        [Required] 
        public string bio {get; set;} = string.Empty;

        [Required]
        public int AwardCount {get; set;}
    }
}