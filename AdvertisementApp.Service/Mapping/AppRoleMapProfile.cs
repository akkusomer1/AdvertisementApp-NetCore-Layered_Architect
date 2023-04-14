using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.AdvertisementApp.Core.Dtos.AppRoleDtos;
using Udemy.AdvertisementApp.Core.Entities;

namespace Udemy.AdvertisementApp.Service.Mapping
{
	public class AppRoleMapProfile:Profile
	{
		public AppRoleMapProfile()
		{
			CreateMap<AppRole,AppRoleListDto>().ReverseMap();
			CreateMap<AppRole,AppRoleCrateDto>().ReverseMap();
			CreateMap<AppRole,AppRoleUpdateDto>().ReverseMap();
		}
	}
}
