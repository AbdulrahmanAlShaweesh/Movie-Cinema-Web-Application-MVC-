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
    public class ProducerController : Controller
    {
        private readonly MovieCinemaDbContext _context;
        
        public ProducerController(MovieCinemaDbContext context) 
        {
            _context = context;
        }

        [HttpGet] 
        public async Task<IActionResult> GetAllProducers(){
            var Producers = await _context.Producers.Include(p => p.Movies).ToListAsync();
                return View(Producers);
        }
    }
}