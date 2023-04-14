using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;
using Udemy.AdvertisementApp.Core.Dtos.AdvertisementAppUserDtos;
using Udemy.AdvertisementApp.Core.Dtos.MilitaryStatusDtos;
using Udemy.AdvertisementApp.Core.Enums;
using Udemy.AdvertisementApp.Core.ResponseObject;
using Udemy.AdvertisementApp.Core.Services;
using Udemy.AdvertisementApp.Service.Services;
using Udemy.AdvertisementApp.UI.Extantion;
using Udemy.AdvertisementApp.UI.Models;

namespace Udemy.AdvertisementApp.UI.Controllers
{
    public class AdvertisementController : Controller
    {
        private readonly IAppUserService _appUserService;
        private readonly IAdvertisementAppUserService _advertisementUserService;

        public AdvertisementController(IAppUserService appUserService, IAdvertisementAppUserService advertisementUserService)
        {
            _appUserService = appUserService;
            _advertisementUserService = advertisementUserService;
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> List()
        {
            var list = await _advertisementUserService.GetList(AdvertisementAppUserStatusType.Başvurdu);

            return View(list);
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> SetStatus(int advertisementId, AdvertisementAppUserStatusType type)
        {
            await _advertisementUserService.SetStatus(advertisementId, type);


            return Redirect("List");
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> ApprovedList()
        {
            var list = await _advertisementUserService.GetList(AdvertisementAppUserStatusType.Mülakat);
            return View(list);
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> RejectedList()
        {
            var list = await _advertisementUserService.GetList(AdvertisementAppUserStatusType.Olumsuz);
            return View(list);
        }

        [Authorize(Roles = "Member")]
        [HttpGet]
        public async Task<IActionResult> Send(int advertisementId)
        {
            var userId = int.Parse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value);
            var userInfoResponse = await _appUserService.GetByIdAsync(userId);
            ViewBag.GenderId = userInfoResponse.Data.GenderId;

            List<MilitaryStatusListDto> list = new List<MilitaryStatusListDto>();

            var items = Enum.GetValues(typeof(MilitaryStatusType));

            foreach (int item in items)
            {

                list.Add(new MilitaryStatusListDto
                {
                    Id = item,
                    Definition = Enum.GetName(typeof(MilitaryStatusType), item)
                });
            }

            ViewBag.MilitaryStatus = new SelectList(list, "Id", "Definition");


            return View(new AdvertisementAppUserCreateVm { AppUserId = userId, AdvertisementId = advertisementId });
        }


        [Authorize(Roles = "Member")]
        [HttpPost]
        public async Task<IActionResult> Send(AdvertisementAppUserCreateVm vm)
        {
            AdvertisementAppUserCreateDto dto = new AdvertisementAppUserCreateDto();

            if (vm.CvFile is not null)
            {
                var fileName = Guid.NewGuid().ToString();
                var extName = Path.GetExtension(vm.CvFile.FileName);
                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "cvFiles", fileName + extName);
                var stream = new FileStream(path, FileMode.Create);
                await vm.CvFile.CopyToAsync(stream);

                dto.CvPath = path;

            }

            //Map'leme işlemini gerçekleştiriyorum.
            dto.AppUserId = vm.AppUserId;
            dto.AdvertisementAppUserStatusId = vm.AdvertisementAppUserStatusId;
            dto.AdvertisementId = vm.AdvertisementId;
            dto.EndDate = vm.EndDate;
            dto.MilitaryStatusId = vm.MilitaryStatusId;
            dto.WorkExperience = vm.WorkExperience;


            var response = await _advertisementUserService.CreateASync(dto);


            if (response.ResponseType == ResponseType.ValidationError)
            {
                //Validation Error'a girdiği anda bunları da tekrar dan gönderiyoruz.
                var userId = int.Parse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value);
                var userInfoResponse = await _appUserService.GetByIdAsync(userId);
                ViewBag.GenderId = userInfoResponse.Data.GenderId;



                List<MilitaryStatusListDto> list = new List<MilitaryStatusListDto>();

                var items = Enum.GetValues(typeof(MilitaryStatusType));

                foreach (int item in items)
                {

                    list.Add(new MilitaryStatusListDto
                    {
                        Id = item,
                        Definition = Enum.GetName(typeof(MilitaryStatusType), item)
                    });
                }

                ViewBag.MilitaryStatus = new SelectList(list, "Id", "Definition");

                //
                foreach (var error in response.ValidateErrors)
                {
                    ModelState.AddModelError("", error.ErrorMessage);
                }

                return View(vm);
            }

            return RedirectToAction("HumanResource", "Home");
        }

        public async Task<IActionResult> HumanResource()
        {
            return View();
        }

    }
}
