using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace CinemaMovieWebApplication.Models.Entities
{
    public class ApplicationUser : IdentityUser
    {
        [Required] 
        public string Role {get; set;} = string.Empty;
    }
}