using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations; 

namespace CinemaMovieWebApplication.Data.viewModel
{
    public class CreateViewModel
    {
        [Required(ErrorMessage = "Profile Picture is Required")]
        [Display(Name = "Profile Picture URL")]
        public IFormFile? ProfileImage {get; set;} 

        
        [Required(ErrorMessage = "Full Name is Required")] 
        [Display(Name = "Full Name")]
        [StringLength(100, ErrorMessage = "Name should be between 0-100 letters")]
        public string FullName {get; set;} = string.Empty; 

        [Required(ErrorMessage = "Biography is Required")] 
        [Display(Name = "Biography")]
        public string bio {get; set;} = string.Empty;

        [Required(ErrorMessage = "Award Number is Required")]
        [Display(Name = "Awards")]
        public int AwardCount {get; set;}
    }
}