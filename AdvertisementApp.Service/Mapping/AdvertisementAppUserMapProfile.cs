using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.AdvertisementApp.Core.Dtos.AdvertisementAppUserDtos;
using Udemy.AdvertisementApp.Core.Entities;

namespace Udemy.AdvertisementApp.Service.Mapping
{
    public class AdvertisementAppUserMapProfile:Profile
    {
        public AdvertisementAppUserMapProfile()
        {
            CreateMap<AdvertisementAppUser, AdvertisementAppUserCreateDto>().ReverseMap();
            CreateMap<AdvertisementAppUser, AdvertisementAppUserListDto>().ReverseMap();
        }
    }
}
