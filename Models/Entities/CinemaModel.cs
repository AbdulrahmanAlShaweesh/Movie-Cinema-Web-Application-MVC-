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
        
        [Display(Name = "Logo Image URL")]
        public string Logo {get; set;} = string.Empty; 

        [Required] 
        [StringLength(maximumLength: 100, MinimumLength = 5, ErrorMessage = "Ciema Name should between 5 and 100 letters")]
        [Display(Name = "Cinema Name")]
        public string Name {get; set;} = string.Empty; 

        [Required]
        [Display(Name = "Description")]
        public string Description {get; set;} = string.Empty;

        [Required]
        [Display(Name = "Location")]
        public string Location {get; set;} = string.Empty; 

        [Required] 
        [StringLength(maximumLength:15)]
        [Display(Name = "Phone Number")]
        public string PhoneNumber {get; set;} = string.Empty; 

        [Required]
        [Display(Name = "Opening Hours")]
        public string OpeningHours {get; set;} = string.Empty; 

        [Display(Name = "Website")]
        public string Website {get; set;} = string.Empty; 
        
        [Display(Name = "Email Address")]
        public string Email {get; set;} = string.Empty; 

        [Display(Name = "Facilities")]
        public List<String>? Facilities {get; set;}    // VIP , 3D , IMA

        public ICollection<MovieCinemaModel>? MoviesCinemas {get; set;}
    }
}