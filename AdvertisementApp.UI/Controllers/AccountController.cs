
using AutoMapper.Execution;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Numerics;
using System.Security.Claims;
using Udemy.AdvertisementApp.Core.Dtos.AppUserDtos;
using Udemy.AdvertisementApp.Core.Enums;
using Udemy.AdvertisementApp.Core.ResponseObject;
using Udemy.AdvertisementApp.Core.Services;
using Udemy.AdvertisementApp.UI.Extantion;
using Udemy.AdvertisementApp.UI.Models;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Udemy.AdvertisementApp.UI.Controllers
{
    public class AccountController : Controller
    {
        private readonly IGenderService _genderService;
        private readonly IValidator<UserCreateVm> _validator;
        private readonly IAppUserService _appUserService;
        public AccountController(IGenderService service, IValidator<UserCreateVm> validator, IAppUserService appUserService)
        {
            _genderService = service;
            _validator = validator;
            _appUserService = appUserService;
        }

        [HttpGet]
        public async Task<IActionResult> SignUp()
        {
            var response = await _genderService.GetAllAsync();

            UserCreateVm vm = new UserCreateVm()
            {
                Genders = new SelectList(response.Data, "Id", "Defination")
            };
            return View(vm);
        }


        [HttpPost]
        public async Task<IActionResult> SignUp(UserCreateVm vm)
        {
            var result = _validator.Validate(vm);

            if (result.IsValid)
            {
                AppUserCreateDto userCreateDto = new AppUserCreateDto()
                {
                    Username = vm.Username,
                    Firstname = vm.Firstname,
                    GenderId = vm.GenderId,
                    Password = vm.Password,
                    PhoneNumber = vm.PhoneNumber,
                    Surname = vm.Surname,
                };
                var createResponse = await _appUserService.CreateWithRoleAsync(userCreateDto, (int)RoleType.Member);
                return this.ResponseRedirectAction(createResponse, "SignIn");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
            }
            var response = await _genderService.GetAllAsync();
            vm.Genders = new SelectList(response.Data, "Id", "Defination");
            return View(vm);
        }

        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(AppUserLogInDto logInDto)
        {
            var result = await _appUserService.CheckUser(logInDto);
            if (result.ResponseType == ResponseType.Success)
            {
                var roleList = await _appUserService.GetRolesByUserId(result.Data.Id);

                var claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.NameIdentifier,result.Data.Id.ToString()),
                    new Claim(ClaimTypes.Name,result.Data.Username),
                };

                if (roleList.ResponseType == ResponseType.Success)
                {
                    foreach (var role in roleList.Data)
                    {
                        claims.Add(new Claim(ClaimTypes.Role, role.RoleName));
                    }

                }

                var claimsIdentity = new ClaimsIdentity(
                    claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var authProperties = new AuthenticationProperties
                {
                    IsPersistent = logInDto.RememberMe
                };

                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    authProperties);
                return RedirectToAction("Index", "Home");
            }
            ModelState.AddModelError("Kullanıcı adı veya şifre hatalı", result.Message);
            return View(logInDto);
        }


        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync( CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }
    }


}
