using AutoMapper;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Udemy.AdvertisementApp.Core.Dtos.AdvertisementDtos;
using Udemy.AdvertisementApp.Core.Dtos.AppUserDtos;
using Udemy.AdvertisementApp.Core.Dtos.GenderDtos;
using Udemy.AdvertisementApp.Core.Dtos.ProvidedServiceDtos;
using Udemy.AdvertisementApp.Core.Services;
using Udemy.AdvertisementApp.Core.UnitOfWork;
using Udemy.AdvertisementApp.Data.UnitofWork;
using Udemy.AdvertisementApp.Service.Mapping;
using Udemy.AdvertisementApp.Service.Services;
using Udemy.AdvertisementApp.Service.ValidationRules;

namespace Udemy.AdvertisementApp.Service.Extantion
{
    public static class DependencyExtantion
    {
        public static void AddDependencies(this IServiceCollection Services)
        {
            var mapperConfiguration = new MapperConfiguration(opt =>
            {
                opt.AddProfile(typeof(MapProfile));
                opt.AddProfile(typeof(AdvertisementMapProfile));
                opt.AddProfile(typeof(AppUserMapProfile));
                opt.AddProfile(typeof(GenderMapProfile));
                opt.AddProfile(typeof(AppRoleMapProfile));


            });

            Services.AddAutoMapper(typeof(MapProfile));
            //Services.AddAutoMapper(Assembly.GetExecutingAssembly());

            Services.AddScoped<IUnitOfWork, UnitOfWork>();
            Services.AddScoped<IProvidedServiceService, ProvidedServiceService>();
            Services.AddScoped<IAdvertisementService, AdvertisementService>();
            Services.AddScoped<IGenderService, GenderService>();
            Services.AddScoped<IAppUserService, AppUserService>();
            Services.AddScoped<IAdvertisementAppUserService, AdvertisementAppUserService>();


			Services.AddControllersWithViews();
			//.AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<ProvidedServiceCreateDtoValidator>());

			Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            //Services.AddTransient<IValidator<ProvidedServiceCreateDto>, ProvidedServiceCreateDtoValidator>();
            //Services.AddTransient<IValidator<ProvidedServiceUpdateDto>, ProvidedServiceUpdateDtoValidator>();
         
            //Services.AddTransient<IValidator<AdvertisementCreateDto>, AdvertisementCreateDtoValidator>();
            //Services.AddTransient<IValidator<AdvertisementUpdateDto>, AdvertisementUpdateDtoValidator>();
            //Services.AddTransient<IValidator<AppUserUpdateDto>, AppUserUpdateDtoValidator>();
            //Services.AddTransient<IValidator<AppUserCreateDto>, AppUserCreateDtoValidator>();
            //Services.AddTransient<IValidator<GenderCreateDto>, GenderCreateDtoValidator>();
            //Services.AddTransient<IValidator<GenderUpdateDto>, GenderUpdateDtoValidator>();
             //Services.AddTransient<IValidator<AppUserLogInDto>, AppUserLogInDtoValidator>();
        }
    }
}
