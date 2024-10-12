using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using CinemaMovieWebApplication.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CinemaMovieWebApplication.Controllers
{
     
    public class AviableMoviesController : Controller
    {
        private readonly MovieCinemaDbContext _context; 

        public AviableMoviesController(MovieCinemaDbContext context)
        {
            _context = context;
        }

        [HttpGet] 
        public async Task<IActionResult> GetAllMovies(){
            var Movies = await _context.Movies.Include(n => n.MoviesCinemas).ThenInclude(c => c.Cinema).ToListAsync();
            
            return View(Movies);
        }
    }
}

