using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Udemy.AdvertisementApp.Core.Dtos.AdvertisementDtos;
using Udemy.AdvertisementApp.Core.Services;
using Udemy.AdvertisementApp.UI.Extantion;

namespace Udemy.AdvertisementApp.UI.Controllers
{
    [Authorize(Roles ="Admin")]
    public class ApplicationController : Controller
    {
        private readonly IAdvertisementService _advertisementService;

        public ApplicationController(IAdvertisementService advertisementService)
        {
            _advertisementService = advertisementService;
        }

        public async  Task<IActionResult> Index()
        {
         var response=await   _advertisementService.GetAllAsync();
            return this.ResponseView(response);
        }


        [HttpGet]
        public async  Task<IActionResult> Create()
        {         
            return View();
        } 
        
        [HttpPost]
        public async  Task<IActionResult> Create(AdvertisementCreateDto dto)
        {
            var response = await _advertisementService.CreateAsync(dto);
            return  this.ResponseRedirectAction(response,"Index", "Application");
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
           var updateData= await _advertisementService.GetByIdAsync(id);


            return this.ResponseView(updateData);
        }
        
        [HttpPost]
        public async Task<IActionResult> Update(AdvertisementUpdateDto dto)
        {
         var response=  await _advertisementService.UpdateAsync(dto);
            return this.ResponseRedirectAction(response, "Index", "Application");
        }

    
        public async Task<IActionResult> Remove(int id)
        {
            await  _advertisementService.RemoveAsync(id);
            return RedirectToAction("Index", "Application");
        }

        public async Task<IActionResult> GetPersonel()
        {
            return View();
        }

    }
}
