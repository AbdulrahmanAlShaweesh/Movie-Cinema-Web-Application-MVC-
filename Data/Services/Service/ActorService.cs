using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CinemaMovieWebApplication.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CinemaMovieWebApplication.Data.Services.Service
{
    public class ActorService : IActorRepository
    {
        private readonly MovieCinemaDbContext _context; 

        public ActorService(MovieCinemaDbContext context)
        {
            _context = context; 
        }

        public async Task<ActorModel> CreateActorAsync(ActorModel Actor)
        {
           await _context.Actors.AddAsync(Actor);
           await _context.SaveChangesAsync();
           return Actor;
        }

        public void DeleteActor(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ActorModel>> GetAllAsync()
        {
            var actors = await _context.Actors.ToListAsync();
            return actors;
        }

        public async Task<ActorModel?> GetByIdAsync(int id)
        {
            var result = await _context.Actors.FirstOrDefaultAsync(a => a.Id == id);
            
            return result;
        }

        public ActorModel? UpdateActorAsync(int id, ActorModel newActor)
        {
            throw new NotImplementedException();
        }
    }
}