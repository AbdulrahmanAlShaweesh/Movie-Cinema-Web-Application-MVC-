using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaMovieWebApplication.Data.viewModel
{
    public class CinemaUpdateViewModel
    {
        public int Id {get; set;}
        public IFormFile? Logo {get; set;}  
        
        public string Name {get; set;} = string.Empty; 
        
        public string Description {get; set;} = string.Empty;
        
        public string Location {get; set;} = string.Empty; 
        
        public string PhoneNumber {get; set;} = string.Empty; 
        
        public string OpeningHours {get; set;} = string.Empty; 
        
        public string Website {get; set;} = string.Empty; 
        
        public string Email {get; set;} = string.Empty; 
        
        public List<String>? Facilities {get; set;}    // VIP , 3D , IMA
        public string ExistingImage {get; set;} = string.Empty;
    }
}