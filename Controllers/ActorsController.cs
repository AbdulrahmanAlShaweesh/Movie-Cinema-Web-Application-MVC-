using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CinemaMovieWebApplication.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CinemaMovieWebApplication.Controllers
{
    public class ActorsController : Controller
    {
        private readonly MovieCinemaDbContext _context; 

        public ActorsController(MovieCinemaDbContext context)
        {
            _context = context;
        }

        [HttpGet] 
        public async Task<IActionResult> GetAllActors() {
            var Actors = await _context.Actors.ToListAsync(); 

            return View(Actors);
        } // crud
    }
}