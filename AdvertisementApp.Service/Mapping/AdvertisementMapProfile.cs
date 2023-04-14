using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.AdvertisementApp.Core.Dtos.AdvertisementDtos;
using Udemy.AdvertisementApp.Core.Entities;

namespace Udemy.AdvertisementApp.Service.Mapping
{
    public class AdvertisementMapProfile:Profile
    {
        public AdvertisementMapProfile()
        {
            CreateMap<Advertisement,AdvertisementCreateDto>().ReverseMap();
            CreateMap<Advertisement,AdvertisementUpdateDto>().ReverseMap();
            CreateMap<Advertisement,AdvertisementListDto>().ReverseMap();
        }
    }
}
