using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.AdvertisementApp.Core.Dtos.AdvertisementAppUserStatusDtos;
using Udemy.AdvertisementApp.Core.Entities;

namespace Udemy.AdvertisementApp.Service.Mapping
{
    public class AdvertisementAppUserStatusMapProfile:Profile
    {
        public AdvertisementAppUserStatusMapProfile()
        {
            CreateMap<AdvertisementAppUserStatus, AdvertisementAppUserStatusListDto>().ReverseMap();
        }
    }
}
