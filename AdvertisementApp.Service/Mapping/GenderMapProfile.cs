using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.AdvertisementApp.Core.Dtos.GenderDtos;
using Udemy.AdvertisementApp.Core.Entities;

namespace Udemy.AdvertisementApp.Service.Mapping
{
    public class GenderMapProfile:Profile
    {
        public GenderMapProfile()
        {
            CreateMap<Gender, GenderListDto>().ReverseMap();
            CreateMap<Gender, GenderCreateDto>().ReverseMap();
            CreateMap<Gender, GenderUpdateDto>().ReverseMap();
        }
       

    }
}
