using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CinemaMovieWebApplication.Data.Base;
using CinemaMovieWebApplication.Models.Entities;

namespace CinemaMovieWebApplication.Data.Services.Interfaces
{
    public interface IMovieRepository : IEntityBaseRepository<MovieModel>
    {
         Task<IEnumerable<ProducerModel>> GetAllProducersAsync();
    }
}