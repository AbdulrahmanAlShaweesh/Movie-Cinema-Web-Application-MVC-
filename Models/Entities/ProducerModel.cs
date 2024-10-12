using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaMovieWebApplication.Models.Entities
{
    public class ProducerModel
    {
        [Key] 
        public int Id {get; set;} 

        [Required] 
        [Display(Name = "Profile Picture URL")]
        public string ProducerProfileImage {get; set;} = string.Empty;

        [Required] 
        [Display(Name = "Full Name")]
        [StringLength(100, ErrorMessage = "Name should be between 0-100 letters")]
        public string ProducerName {get; set;} = string.Empty; 

        [Required] 
        [Display(Name = "Biography")]
        public string bio {get; set;} = string.Empty;

        public ICollection<MovieModel>? Movies {get; set;}
    }
}