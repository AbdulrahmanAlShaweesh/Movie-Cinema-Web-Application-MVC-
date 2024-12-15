using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CinemaMovieWebApplication.Data.Base;
using CinemaMovieWebApplication.Data.Services.Interfaces;
using CinemaMovieWebApplication.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CinemaMovieWebApplication.Data.Services.Service
{
    public class MovieServices : EntityBaseRepository<MovieModel>, IMovieRepository
    {
        private readonly MovieCinemaDbContext _context;
        public MovieServices(MovieCinemaDbContext context) : base (context){ 
            _context = context;
        }

        public async Task<IEnumerable<ProducerModel>> GetAllProducersAsync()
        {
            return await _context.Producers.ToListAsync();
        }
    }
}