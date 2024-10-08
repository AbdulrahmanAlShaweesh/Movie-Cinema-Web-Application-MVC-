using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CinemaMovieWebApplication.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CinemaMovieWebApplication.Data
{
    public class MovieCinemaDbContext : DbContext
    {
        public MovieCinemaDbContext(DbContextOptions<MovieCinemaDbContext> options) : base(options)
        {
            
        }

        DbSet<ActorModel> Actors {get; set;}
        DbSet<CinemaModel> Cinemas {get; set;}
        DbSet<MovieModel> Movies {get; set;} 
        DbSet<ProducerModel> Producers {get; set;}
        DbSet<MovieCinemaModel> MovieCinema {get; set;}
        DbSet<ActorMovieModel> ActorMovies {get; set;} 
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ActorMovieModel>()
            .HasKey(am => new {
                am.ActorId, am.MovieId,
            });

            modelBuilder.Entity<ActorMovieModel>().
            HasOne(m => m.Movies).WithMany(am => am.ActorsMovies)
            .HasForeignKey(m => m.MovieId);

            modelBuilder.Entity<ActorMovieModel>()
            .HasOne(a => a.Actors).WithMany(m => m.ActorsMovies)
            .HasForeignKey(a => a.ActorId);

            modelBuilder.Entity<MovieCinemaModel>()
            .HasKey(mc => new {
                mc.MovieId, mc.CinemaId,
            });

             modelBuilder.Entity<MovieCinemaModel>()
            .HasOne(a => a.Movies).WithMany(m => m.MoviesCinemas)
            .HasForeignKey(a => a.MovieId);

             modelBuilder.Entity<MovieCinemaModel>()
            .HasOne(a => a.Cinema).WithMany(m => m.MoviesCinemas)
            .HasForeignKey(a => a.CinemaId);

            base.OnModelCreating(modelBuilder);
        }
    }
}