using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaMovieWebApplication.Data.viewModel
{
    public class CreateProducerViewModel
    {
      
        [Required(ErrorMessage = "Profile Picture is Required")]
        [Display(Name = "Profile Picture URL")]
        public IFormFile? ProducerProfileImage {get; set;} 
         
        public string ProducerName {get; set;} = string.Empty; 

         
        public string bio {get; set;} = string.Empty;
        
    }
}