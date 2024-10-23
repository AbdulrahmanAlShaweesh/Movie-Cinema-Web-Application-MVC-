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

        public ActorsController(IActorRepository service, IWebHostEnvironment webHostEnvironment)
        {
            _service = service;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllActors()
        {
            var actors = await _service.GetAllAysnc();
            return View(actors);
        }

        [HttpGet]
        public IActionResult CreateActor()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateActor(CreateViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);  // Return the form with validation errors
            }

            // Handle image upload if there's a file
            string profileImagePath = string.Empty;
            if (viewModel.ProfileImage != null)
            {
                string uploadDir = Path.Combine(_webHostEnvironment.WebRootPath, "assets/actorsImages");
                string fileName = $"{viewModel.FullName.Replace(" ", "")}.jpeg";
                string imageFullPath = Path.Combine(uploadDir, fileName);

                if (!Directory.Exists(uploadDir))
                {
                    Directory.CreateDirectory(uploadDir);
                }

                using (var stream = new FileStream(imageFullPath, FileMode.Create))
                {
                    await viewModel.ProfileImage.CopyToAsync(stream);
                }

                profileImagePath = $"/assets/actorsImages/{fileName}";
            }

            var actor = new ActorModel
            {
                FullName = viewModel.FullName,
                bio = viewModel.bio,
                AwardCount = viewModel.AwardCount,
                ProfileImage = profileImagePath // Save relative path of the image
            };

            await _service.CreateAsync(actor);
            return RedirectToAction(nameof(GetAllActors));
        }

        [HttpGet]   
        public async Task<IActionResult> Edit(int id)
        {
            var actor = await _service.GetByIdAsync(id);
            if (actor == null) return View("Empty");

            var actorViewModel = new ActorViewModel
            {
                Id = actor.Id,
                FullName = actor.FullName,
                Bio = actor.bio,
                AwardCount = actor.AwardCount,
                ExistingImage = actor.ProfileImage
            };

            return View(actorViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, ActorViewModel actorViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(actorViewModel);
            }

            var actor = await _service.GetByIdAsync(id);
            if (actor == null) return View("Empty");

            if (actorViewModel.ProfileImage != null)
            {
                // Handle image upload
                string uploadDir = Path.Combine(_webHostEnvironment.WebRootPath, "assets/actorsImages");
                string fileName = $"{actorViewModel.FullName.Replace(" ", "")}.jpeg";
                string imageFullPath = Path.Combine(uploadDir, fileName);

                using (var stream = new FileStream(imageFullPath, FileMode.Create))
                {
                    await actorViewModel.ProfileImage.CopyToAsync(stream);
                }

                actor.ProfileImage = $"/assets/actorsImages/{fileName}";
            }

            actor.FullName = actorViewModel.FullName;
            actor.bio = actorViewModel.Bio;
            actor.AwardCount = actorViewModel.AwardCount;

            await _service.UpdateAsync(id, actor);

            return RedirectToAction(nameof(GetAllActors));
        }
    
        [HttpGet]
        public async Task<IActionResult> ActorDetaial(int id)
        {
            // Retrieve actor details from the service
            var actorDetails = await _service.GetByIdAsync(id);

            // Check if the actor exists
            if (actorDetails == null)
            {
                return View("Empty");
            }

            return View(actorDetails); // Pass the actor details to the view
        }
        


        [HttpPost]
        [ValidateAntiForgeryToken] // This attribute is good for security
        public async Task<IActionResult> Delete(int id)
        {
            var result = await  _service.DeleteAsync(id);
            if (!result)
            {
                return NotFound(); // Return 404 if not found
            }
            return RedirectToAction("GetAllActors"); // Redirect back to the actor list
        }

        public new IActionResult Empty(){
            return View();
        }
    
    }
}




 