using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using CinemaMovieWebApplication.Data;
using CinemaMovieWebApplication.Data.Base;
using CinemaMovieWebApplication.Data.Services.Interfaces;
using CinemaMovieWebApplication.Data.viewModel;
using CinemaMovieWebApplication.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CinemaMovieWebApplication.Controllers
{
    
    public class MovieController : Controller
    {
        private readonly IMovieRepository _services;
        private readonly IWebHostEnvironment _webhostEnvironment;

        public MovieController(IMovieRepository services, IWebHostEnvironment webHostEnvironment)
        {
            _services = services; 
            _webhostEnvironment = webHostEnvironment;
        }



        [HttpGet] 
        public async Task<IActionResult> Read(){  //CRUD
            var Movies = await _services.GetAllAysnc(n => n.MoviesCinemas);

            return View(Movies);
        }
    
        [HttpGet]
        public async Task<IActionResult> Create(){
            ViewBag.Producers = new  SelectList(await _services.GetAllProducersAsync(), "Id", "ProducerName");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateMovieVeiwModel createMovie){
            
            if(!ModelState.IsValid){
                ViewBag.Producers = new SelectList(await _services.GetAllProducersAsync(), "Id", "ProducerName");
                return View(createMovie);
            }

            string LogoImagePath = string.Empty; 

            if(createMovie.MoviePoster != null){
                string UploadDir = Path.Combine(_webhostEnvironment.WebRootPath, "assets/MovieImages");
                string FileName = $"{createMovie.Title.Replace(" ", "")}.jpeg";
                string ImageFullPath = Path.Combine(UploadDir, FileName);

                if(!Directory.Exists(UploadDir)){
                    Directory.CreateDirectory(UploadDir);
                }

                using (var stream = new FileStream(ImageFullPath, FileMode.Create)){
                    // await $"~/assets/MovieImages/{FileName}";
                    await createMovie.MoviePoster.CopyToAsync(stream);
                }

                LogoImagePath = $"~/assets/MovieImages/{FileName}";

            }

            var Movies = new MovieModel {
                Title = createMovie.Title,
                Description = createMovie.Description,
                Price = createMovie.Price,
                MovieUrl = createMovie.MovieUrl,
                Rating = createMovie.Rating,
                Duration = createMovie.Duration,
                ReleaseDate = createMovie.ReleaseDate,
                MovieTypes = createMovie.MovieTypes, 
                Language = createMovie.Language,
                Director = createMovie.Director,
                ProductionCompany = createMovie.ProductionCompany,
                ProducerId = createMovie.ProducerId,
                MoviePoster = LogoImagePath,
            };

            try{
                await _services.CreateAsync(Movies);
                return RedirectToAction(nameof(Read));
            }
            catch (DbUpdateException ex){
                ModelState.AddModelError("", "Unable to save changes. " + ex.Message);
                ViewBag.Producers = new SelectList(await _services.GetAllProducersAsync(), "Id", "ProducerName");
                return View(createMovie);
            }
        }
    
        [HttpGet]
        public async Task<IActionResult> Edit(int id){
            var Movie = await _services.GetByIdAsync(id);

            if(Movie == null) return View("Empty");

            var MovieViewModel = new CreateMovieVeiwModel {
                Title = Movie.Title,
                Description = Movie.Description,
                Price = Movie.Price,
                MovieUrl = Movie.MovieUrl,
                Rating = Movie.Rating,
                Duration = Movie.Duration,
                ReleaseDate = Movie.ReleaseDate,
                MovieTypes = Movie.MovieTypes,
                Language = Movie.Language,
                Director = Movie.Director,
                ProductionCompany = Movie.ProductionCompany,
                ExistingImage = Movie.MoviePoster ?? string.Empty,
            };

            return View(MovieViewModel); 
        }

        public async Task<IActionResult> Edit(int Id, CreateMovieVeiwModel CreateMovie){
            if(!ModelState.IsValid){
                ViewBag.Producers = new SelectList(await _services.GetAllProducersAsync(), "Id", "ProducerName");
                return View(CreateMovie);
            }

            var Movie = await _services.GetByIdAsync(Id);
            if(Movie == null) return View("Empty");

            Movie.Title = CreateMovie.Title;
            Movie.Description = CreateMovie.Description;
            Movie.Price = CreateMovie.Price;
            Movie.MovieUrl = CreateMovie.MovieUrl;
            Movie.Rating = CreateMovie.Rating;
            Movie.Duration = CreateMovie.Duration;
            Movie.ReleaseDate = CreateMovie.ReleaseDate;
            Movie.MovieTypes = CreateMovie.MovieTypes;
            Movie.Language = CreateMovie.Language;
            Movie.Director = CreateMovie.Director;
            Movie.ProductionCompany = CreateMovie.ProductionCompany;
            Movie.ProducerId = CreateMovie.ProducerId;

            if(CreateMovie.MoviePoster != null) {
                string UploadDir = Path.Combine(_webhostEnvironment.WebRootPath, "assets/MovieImages");
                string FileName = $"{CreateMovie.Title.Replace(" ", "")}.jpeg";
                string ImageFullPath = Path.Combine(UploadDir, FileName);

                if (!Directory.Exists(UploadDir))
                {
                    Directory.CreateDirectory(UploadDir);
                }

                using (var stream = new FileStream(ImageFullPath, FileMode.Create)){
                    await CreateMovie.MoviePoster!.CopyToAsync(stream);
                }

                Movie.MoviePoster = $"assets/MovieImages/{FileName}";
            }

            
            await _services.UpdateAsync(Id, Movie); 

            return RedirectToAction(nameof(Read));
        }

        public new IActionResult Empty(){
            return View();
        }
    }
}