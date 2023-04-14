using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.AdvertisementApp.Core.Dtos.MilitaryStatusDtos;
using Udemy.AdvertisementApp.Core.Entities;

namespace Udemy.AdvertisementApp.Service.Mapping
{
    public class MilitaryStatusMapProfile:Profile
    {
        public MilitaryStatusMapProfile()
        {
            CreateMap<MilitaryStatus, MilitaryStatusListDto>().ReverseMap();
        }
    }
}
