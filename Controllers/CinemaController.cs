using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using CinemaMovieWebApplication.Data;
using CinemaMovieWebApplication.Data.Services.Interfaces;
using CinemaMovieWebApplication.Data.viewModel;
using CinemaMovieWebApplication.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CinemaMovieWebApplication.Controllers
{
     
    public class CinemaController : Controller
    { 

         private readonly ICinemaRepository _services;
         private readonly IWebHostEnvironment _webHostEnvironment; 

         public CinemaController(ICinemaRepository services, IWebHostEnvironment webHostEnvironment)
         {
            _services = services; 
            _webHostEnvironment = webHostEnvironment;
         }


         [HttpGet]
         public async Task<IActionResult> GetAllCinemas() {
            var Cinemas = await _services.GetAllAysnc() ;

            return View(Cinemas);
         }

         [HttpGet]
         public  IActionResult Create(){
            return   View();
         }

         [HttpPost]
         public async Task<IActionResult> Create(CreateCinemaViewModel createCinema)
         {
            
            if(!ModelState.IsValid){
               return View(createCinema);
            }
            
            string LogoImagePath = string.Empty;

            if(createCinema.Logo != null){

               string UploadDir = Path.Combine(_webHostEnvironment.WebRootPath, "assets/CinemasImages");
               string FileName = $"{createCinema.Name.Replace(" ", "")}.jpeg";
               string ImageFullPath = Path.Combine(UploadDir, FileName);
         
               if(!Directory.Exists(UploadDir)){
                  Directory.CreateDirectory(UploadDir);
               }

               using (var stream = new FileStream(ImageFullPath, FileMode.Create)){
                  await createCinema.Logo.CopyToAsync(stream);
               }

               LogoImagePath = $"~/assets/CinemasImages/{FileName}";
               
            }

            var Cinema = new CinemaModel
               {
                  Name = createCinema.Name, 
                  Description = createCinema.Description,
                  Location = createCinema.Location,
                  PhoneNumber = createCinema.PhoneNumber,
                  OpeningHours = createCinema.OpeningHours,
                  Website = createCinema.Website, 
                  Email = createCinema.Email,
                  Facilities = createCinema.Facilities,
                  Logo = LogoImagePath
               };

               await _services.CreateAsync(Cinema);
               return RedirectToAction(nameof(GetAllCinemas));
            
         }

         [HttpGet]
         public async Task<IActionResult> Edit(int Id){
            
            var Cinema = await _services.GetByIdAsync(Id);

            if(Cinema == null) return View("Empty");

            var CinemaViewModel = new CreateCinemaViewModel {
                Name = Cinema.Name,
                Description = Cinema.Description,
                Location = Cinema.Location,
                PhoneNumber = Cinema.PhoneNumber, 
                OpeningHours = Cinema.OpeningHours,
                Website = Cinema.Website,
                Email = Cinema.Email,
                Facilities = Cinema.Facilities,
            };

            return View(CinemaViewModel);
         }
   
         [HttpPost]
         public async Task<IActionResult> Edit(int Id, CreateCinemaViewModel CreateCinema){

            if(!ModelState.IsValid){
               return View(CreateCinema);
            }

            var Cinema = await _services.GetByIdAsync(Id);
            if (Cinema == null) return View("Empty");

            if(CreateCinema.Logo != null) {
               string UploadDir = Path.Combine(_webHostEnvironment.WebRootPath, "assets/CinemasImages");
               string FileName = $"{CreateCinema.Name.Replace(" ", "")}.jpeg";
               string ImageFullPath = Path.Combine(UploadDir, FileName);

               using (var stream = new FileStream(ImageFullPath, FileMode.Create)){
                  await CreateCinema.Logo.CopyToAsync(stream);
               }

               Cinema.Logo = $"~/assets/CinemasImages/{FileName}";
            }
            
            Cinema.Name = CreateCinema.Name;
            Cinema.Description = CreateCinema.Description;
            Cinema.Location = CreateCinema.Location;
            Cinema.PhoneNumber = CreateCinema.PhoneNumber;
            Cinema.OpeningHours = CreateCinema.OpeningHours; 
            Cinema.Website = CreateCinema.Website;
            Cinema.Email = CreateCinema.Email; 
            Cinema.Facilities = CreateCinema.Facilities;

            await _services.UpdateAsync(Id, Cinema);
            return RedirectToAction(nameof(GetAllCinemas));

         }
    
         public async Task<IActionResult> Details(int id){
            var Cinema = await _services.GetByIdAsync(id); 

            if(Cinema == null) {
               return View("Empty");
            }

            return View(Cinema);
         }  
    
         public async Task<IActionResult> Delete(int id){
               var Cinema = await _services.DeleteAsync(id);

               if(!Cinema){
                  return NotFound();
               }

               return RedirectToAction("GetAllCinemas");
         }

         public new IActionResult Empty(){
            return View();
         }
    }
}