using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CinemaMovieWebApplication.Data.Base;
using CinemaMovieWebApplication.Data.viewModel;
using CinemaMovieWebApplication.Models.Entities;

namespace CinemaMovieWebApplication.Data.Services
{
    public interface IActorRepository : IEntityBaseRepository<ActorModel>
    {
        // Task<List<ActorModel>> GetAllAsync();
        // Task<ActorModel?> GetByIdAsync(int id);
        // Task CreateActorAsync(ActorModel actor);
        // Task UpdateActorAsync(int id, ActorModel actor);
        // Task<bool> DeleteActorAsync(int id); // Make sure this is included
    }
}