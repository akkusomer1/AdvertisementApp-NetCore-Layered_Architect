using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Udemy.AdvertisementApp.Core.Dtos.ProvidedServiceDtos;
using Udemy.AdvertisementApp.Core.ResponseObject;
using Udemy.AdvertisementApp.Core.Services;
using Udemy.AdvertisementApp.UI.Extantion;
using Udemy.AdvertisementApp.UI.Models;

namespace Udemy.AdvertisementApp.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProvidedServiceService _providedService;
        private readonly IAdvertisementService _advertisementService;

        public HomeController(IProvidedServiceService providedService, IAdvertisementService advertisementService)
        {
            _providedService = providedService;
            _advertisementService = advertisementService;
        }


        public async Task<IActionResult> Index()
        {
            IDataGenericResponse<List<ProvidedServiceListDto>> response = await _providedService.GetAllAsync();
            return this.ResponseView(response);
        }  
        
        
        public async Task<IActionResult> HumanResource()
        {
           var response= await  _advertisementService.GetActivesAsync();
           return this.ResponseView(response);
        }

       

    }
}