using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CinemaMovieWebApplication.Models.Entities;

namespace CinemaMovieWebApplication.Data.Services
{
    public interface IActorRepository
    {
        Task<List<ActorModel>> GetAllAsync();  

        Task<ActorModel?> GetByIdAsync(int id); 

        Task<ActorModel> CreateActorAsync(ActorModel Actor);   // void becouse we do not need to return anythin after we create actor

        ActorModel? UpdateActorAsync(int id, ActorModel newActor);

        void DeleteActor(int id);
    }
}