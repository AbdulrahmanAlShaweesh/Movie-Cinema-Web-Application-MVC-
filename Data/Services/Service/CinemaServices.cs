using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CinemaMovieWebApplication.Data.Base;
using CinemaMovieWebApplication.Data.Services.Interfaces;
using CinemaMovieWebApplication.Models.Entities;

namespace CinemaMovieWebApplication.Data.Services.Service
{
    public class CinemaServices : EntityBaseRepository<CinemaModel>, ICinemaRepository
    {
        public CinemaServices(MovieCinemaDbContext context) : base(context) { }
    }
}