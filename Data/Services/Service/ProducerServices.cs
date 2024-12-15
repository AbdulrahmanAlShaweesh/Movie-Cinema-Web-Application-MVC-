using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CinemaMovieWebApplication.Data.Base;
using CinemaMovieWebApplication.Data.Services.Interfaces;
using CinemaMovieWebApplication.Models.Entities;

namespace CinemaMovieWebApplication.Data.Services.Service
{
    public class ProducerServices : EntityBaseRepository<ProducerModel>, IProducerServices
    {
        public ProducerServices(MovieCinemaDbContext context) : base (context)
        {
            
        }
    }
}