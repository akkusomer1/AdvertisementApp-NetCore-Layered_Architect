using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.AdvertisementApp.Core.Dtos.AppRoleDtos;
using Udemy.AdvertisementApp.Core.Dtos.AppUserDtos;
using Udemy.AdvertisementApp.Core.Entities;
using Udemy.AdvertisementApp.Core.ResponseObject;

namespace Udemy.AdvertisementApp.Core.Services
{
    public interface IAppUserService:IGenericService<AppUserCreateDto,AppUserUpdateDto,AppUserListDto,AppUser>
    {
		Task<IDataGenericResponse<List<AppRoleListDto>>> GetRolesByUserId(int userId);
		Task<IDataGenericResponse<AppUserCreateDto>> CreateWithRoleAsync(AppUserCreateDto appUserCreateDto, int roleId);
        Task<IDataGenericResponse<AppUserListDto>> CheckUser(AppUserLogInDto logInDto);
       
	}
}
