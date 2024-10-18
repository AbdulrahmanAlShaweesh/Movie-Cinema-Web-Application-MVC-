using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CinemaMovieWebApplication.Data.Base;
using CinemaMovieWebApplication.Data.viewModel;
using CinemaMovieWebApplication.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CinemaMovieWebApplication.Data.Services.Service
{
    public class ActorService : EntityBaseRepository<ActorModel>, IActorRepository
    {
       

        public ActorService(MovieCinemaDbContext context) : base(context){ }

        // public async Task<List<ActorModel>> GetAllAsync()
        // {
        //     return await _context.Actors.ToListAsync();
        // }

        //  public async Task<ActorModel?> GetByIdAsync(int id)
        // {
        //     var result = await _context.Actors.FirstOrDefaultAsync(a => a.Id == id);
            
        //     return result;
        // }

        // public async Task CreateActorAsync(ActorModel actor)
        // {
        //     await _context.Actors.AddAsync(actor);
        //     await _context.SaveChangesAsync();
        // }

        // public async Task UpdateActorAsync(int id, ActorModel actorModel)
        // {
        //     var actor = await _context.Actors.FindAsync(id);
        //     if (actor != null)
        //     {
        //         actor.FullName = actorModel.FullName;
        //         actor.bio = actorModel.bio;
        //         actor.AwardCount = actorModel.AwardCount;

        //         if (!string.IsNullOrEmpty(actorModel.ProfileImage))
        //         {
        //             actor.ProfileImage = actorModel.ProfileImage;
        //         }

        //         await _context.SaveChangesAsync();
        //     }
        // }

        // public async Task<bool> DeleteActorAsync(int id)
        //     {
        //         var actor = await _context.Actors.FindAsync(id);
        //         if (actor == null) return false;

        //         _context.Actors.Remove(actor);
        //         await _context.SaveChangesAsync();
        //         return true; // Return true if deletion was successful
        //     }
    }

}