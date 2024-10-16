using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CinemaMovieWebApplication.Data;
using CinemaMovieWebApplication.Data.Services;
using CinemaMovieWebApplication.Data.Services.Service;
using CinemaMovieWebApplication.Data.viewModel;
using CinemaMovieWebApplication.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CinemaMovieWebApplication.Controllers
{
    public class ActorsController : Controller
    {
        private readonly IActorRepository _service; 
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ActorsController(IActorRepository servcies, IWebHostEnvironment webHostEnvironment)
        {
            _service = servcies;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet] 
        public async Task<IActionResult> GetAllActors() {
            var Actors = await _service.GetAllAsync(); 

            return View(Actors);
        } // crud

        // [HttpGet]
        public async Task<IActionResult> ActorDetaial(int id){
            // check if the actor already in the db. 
            var actorDetials = await _service.GetByIdAsync(id); 
            
            if(actorDetials == null) {
                return View("Empty");
            }

            return View(actorDetials);
        }

        public IActionResult Empty(){
            return View();
        }

        [HttpGet]
        public  IActionResult CreateActor(){
            return View();
        }
      
        [HttpPost]
        public async Task<IActionResult> CreateActor(CreateViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);  // Return to the view with validation errors
            }

            // Define the target folder path
            string uploadDir = Path.Combine(_webHostEnvironment.WebRootPath, "assets/actorsImages");
            
            // Ensure the directory exists
            if (!Directory.Exists(uploadDir))
            {
                Directory.CreateDirectory(uploadDir);
            }

            // Create a unique filename using the actor's name or another relevant identifier
            string fileName = $"{viewModel.FullName.Replace(" ", "")}.jpeg"; // Modify the naming convention as needed
            string imageFullPath = Path.Combine(uploadDir, fileName);

            // Save the file asynchronously
            using (var stream = new FileStream(imageFullPath, FileMode.Create))
            {
                await viewModel.ProfileImage!.CopyToAsync(stream);
            }

            // Save the relative path to the database
            var actor = new ActorModel()
            {
                FullName = viewModel.FullName,
                bio = viewModel.bio,
                ProfileImage = $"/assets/actorsImages/{fileName}", // Save as a relative URL
                AwardCount = viewModel.AwardCount,
            };

            await _service.CreateActorAsync(actor);
            return RedirectToAction("GetAllActors");
        }
    }
}