using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaMovieWebApplication.Models.Entities
{
    public class CinemaModel
    {
        [Key] 
        public int Id {get; set;} 
        
        public string Logo {get; set;} = string.Empty; 

        [Required] 
        [StringLength(maximumLength: 100, MinimumLength = 5, ErrorMessage = "Ciema Name should between 5 and 100 letters")]
        public string Name {get; set;} = string.Empty; 

        [Required]
        public string Description {get; set;} = string.Empty;

        [Required]
        public string Location {get; set;} = string.Empty; 

        [Required] 
        [StringLength(maximumLength:15)]
        public string PhoneNumber {get; set;} = string.Empty; 

        [Required]
        public string OpeningHours {get; set;} = string.Empty; 

        public string Website {get; set;} = string.Empty; 

        public string Email {get; set;} = string.Empty; 

        public List<String>? Facilities {get; set;}    // VIP , 3D , IMA

        public ICollection<MovieCinemaModel>? MoviesCinemas {get; set;}
    }
}