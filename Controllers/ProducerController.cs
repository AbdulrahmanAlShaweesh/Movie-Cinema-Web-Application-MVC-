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
    public class ProducerController : Controller
    {
        private readonly IProducerServices _services;
        private readonly IWebHostEnvironment _webHostEnvironment;
        
        public ProducerController(IProducerServices services, IWebHostEnvironment webHostEnvironment) 
        {
            _services = services;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet] 
        public async Task<IActionResult> Read(){
            var Producers = await _services.GetAllAysnc(p => p.Movies!);
                return View(Producers);
        }

        [HttpGet]
        public async Task<IActionResult> Detials(int id) {
            var Producer = await _services.GetByIdAsync(id);

            if (Producer == null) return View("Empty");

            return View(Producer);
        }

        [HttpGet]
        public  IActionResult Create() {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProducerViewModel CreateProducer){
            
            if(!ModelState.IsValid){
                return View(CreateProducer);
            }

            string ProfileImagePath = string.Empty; 

            if(CreateProducer.ProducerProfileImage != null){
                string UploadDir = Path.Combine(_webHostEnvironment.WebRootPath, "assets/Producer");
                string FileName = $"{CreateProducer.ProducerName.Replace(" ", "")}.jpeg";
                string ImageFullPath = Path.Combine(UploadDir, FileName);

                if(!Directory.Exists(UploadDir)) {
                    Directory.CreateDirectory(UploadDir);
                }

                using (var stream = new FileStream(ImageFullPath, FileMode.Create)){
                    await CreateProducer.ProducerProfileImage.CopyToAsync(stream);
                }

                ProfileImagePath = $"/assets/Producer/{FileName}";
            }

            var Producer = new ProducerModel {
                ProducerName = CreateProducer.ProducerName,
                bio = CreateProducer.bio,
                ProducerProfileImage = ProfileImagePath,
            };

            await _services.CreateAsync(Producer);
            return RedirectToAction(nameof(Read));

        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id){
            var Producer = await _services.GetByIdAsync(id);

            if(Producer == null) return View("Empty");
            
            var ProducerViewModels = new UpdateProducerViewModel {
                Id = Producer.Id,
                ProducerName = Producer.ProducerName,
                bio = Producer.bio,
                ExistingImage = Producer.ProducerProfileImage,
            };

            return View(ProducerViewModels);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int Id, UpdateProducerViewModel UpdateProducer){

            if(!ModelState.IsValid){
                return View(UpdateProducer);
            }

            var Producer = await _services.GetByIdAsync(Id);
            if(Producer == null) return View("Empty");

            if(UpdateProducer.ProducerProfileImage != null) {
                string UploadDir = Path.Combine(_webHostEnvironment.WebRootPath, "assets/Producer");
                string FileName = $"{UpdateProducer.ProducerName.Replace(" ", "")}.jpeg";
                string ImageFullPath = Path.Combine(UploadDir, FileName); 

                using (var stream = new FileStream(ImageFullPath, FileMode.Create)){
                    await UpdateProducer.ProducerProfileImage.CopyToAsync(stream);
                }

                Producer.ProducerProfileImage = $"/assets/Producer/{FileName}";
            }

            if(Id == Producer.Id) {
                Producer.ProducerName = UpdateProducer.ProducerName;
                Producer.bio = UpdateProducer.bio;

                await _services.UpdateAsync(Id, Producer);
                return RedirectToAction(nameof(Read));
            }

            return View(Producer);

            
        }

        [HttpPost]
        [ValidateAntiForgeryToken] // This attribute is good for security
        public async Task<IActionResult> Delete(int id) {
            var Producer = await _services.DeleteAsync(id); 

            if(!Producer) {
                return NotFound();
            }

            return RedirectToAction("Read");
        }

         public new IActionResult Empty(){
            return View();
        }
    }
}