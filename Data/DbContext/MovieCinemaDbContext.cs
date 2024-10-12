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

        public DbSet<ActorModel> Actors {get; set;}
        public DbSet<CinemaModel> Cinemas {get; set;}
        public DbSet<MovieModel> Movies {get; set;} 
        public DbSet<ProducerModel> Producers {get; set;}
        public DbSet<MovieCinemaModel> MovieCinema {get; set;}
        public DbSet<ActorMovieModel> ActorMovies {get; set;} 
        public DbSet<ApplicationUser> Users {get; set;} 
        
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
            
            modelBuilder.Entity<ProducerModel>()
            .HasMany(p => p.Movies)
            .WithOne(m => m.Producers)
            .HasForeignKey(m => m.ProducerId);

            base.OnModelCreating(modelBuilder);
        }
    }
}