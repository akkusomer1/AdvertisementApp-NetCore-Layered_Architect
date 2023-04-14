using AutoMapper;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Identity.Client.Extensibility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.AdvertisementApp.Core.Dtos.ProvidedServiceDtos;
using Udemy.AdvertisementApp.Core.Entities;

namespace Udemy.AdvertisementApp.Service.Mapping
{
    public class MapProfile:Profile
    {
        public MapProfile()
        {
            CreateMap<ProvidedService, ProvidedServiceListDto>().ReverseMap();
            CreateMap<ProvidedService, ProvidedServiceCreateDto>().ReverseMap();
            CreateMap<ProvidedService, ProvidedServiceUpdateDto>().ReverseMap();
        }
    }
}
