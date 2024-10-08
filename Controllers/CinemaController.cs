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
     
    public class CinemaController : Controller
    {
         private readonly MovieCinemaDbContext _context; 

         public CinemaController(MovieCinemaDbContext context)
         {
            _context = context;
         }

         [HttpGet]
         public async Task<IActionResult> GetAllCinemas() {
            var Cinemas = await _context.Cinemas.ToListAsync(); 

            return View(Cinemas);
         }
    }
}