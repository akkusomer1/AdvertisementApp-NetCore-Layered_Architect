using AutoMapper;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.AdvertisementApp.Core.Dtos.AppRoleDtos;
using Udemy.AdvertisementApp.Core.Dtos.AppUserDtos;
using Udemy.AdvertisementApp.Core.Entities;
using Udemy.AdvertisementApp.Core.ResponseObject;
using Udemy.AdvertisementApp.Core.Services;
using Udemy.AdvertisementApp.Core.UnitOfWork;
using Udemy.AdvertisementApp.Service.Extantion;

namespace Udemy.AdvertisementApp.Service.Services
{
	public class AppUserService : GenericService<AppUserCreateDto, AppUserUpdateDto, AppUserListDto, AppUser>, IAppUserService
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;
		private readonly IValidator<AppUserCreateDto> _createDtoValidator;
		private readonly IValidator<AppUserLogInDto> _appUserLogInDto;
		public AppUserService(IMapper mapper, IUnitOfWork unitOfWork, IValidator<AppUserCreateDto> createDtoValidator, IValidator<AppUserUpdateDto> updateDtoValidator, IValidator<AppUserLogInDto> appUserLogInDto) : base(mapper, unitOfWork, createDtoValidator, updateDtoValidator)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
			_createDtoValidator = createDtoValidator;
			_appUserLogInDto = appUserLogInDto;

		}

		public async Task<IDataGenericResponse<AppUserCreateDto>> CreateWithRoleAsync(AppUserCreateDto appUserCreateDto, int roleId)
		{
			var result = _createDtoValidator.Validate(appUserCreateDto);

			if (result.IsValid)
			{
				AppUser user = _mapper.Map<AppUser>(appUserCreateDto);

				await _unitOfWork.GetRepository<AppUser>().CreateAsync(user);

				await _unitOfWork.GetRepository<AppUserRole>().CreateAsync(new AppUserRole()
				{
					RoleId = roleId,
					AppUser = user
				});

				await _unitOfWork.CommitAsync();
				return new DataGenericResponse<AppUserCreateDto>(ResponseType.Success, appUserCreateDto);
			}
			return new DataGenericResponse<AppUserCreateDto>(appUserCreateDto, result.CustomValidationError());
		}



		public async Task<IDataGenericResponse<AppUserListDto>> CheckUser(AppUserLogInDto logInDto)
		{
			var result = _appUserLogInDto.Validate(logInDto);
			
			if (result.IsValid)
			{
		     var user=	await _unitOfWork.GetRepository<AppUser>().GetByFilterAsync(x=>x.Username== logInDto.Username && x.Password==logInDto.Password );

				if (user is not null)
				{
					var newUserDto=_mapper.Map<AppUserListDto>(user);
					return new DataGenericResponse<AppUserListDto>(ResponseType.Success, newUserDto);
				}

				return new DataGenericResponse<AppUserListDto>(ResponseType.NotFound, "Kullanıcı adı veya şifre yanlıştır.");
			}

			return new DataGenericResponse<AppUserListDto>(ResponseType.ValidationError, "Kullanıcı adı veya şifre boş olamaz..");
		}

		public async Task<IDataGenericResponse<List<AppRoleListDto>>> GetRolesByUserId(int userId)
		{
		  var roles=	await _unitOfWork.GetRepository<AppRole>().GetAllAsync(x=>x.UserRoles.Any(y=>y.UserId==userId));

			if (roles==null)
			{
				return new DataGenericResponse<List<AppRoleListDto>>(ResponseType.NotFound, "İlgili Role bulunamadı.");
			}

			 List<AppRoleListDto> rolesDto= _mapper.Map<List<AppRoleListDto>>(roles);

			return new DataGenericResponse<List<AppRoleListDto>>(ResponseType.Success, rolesDto);

		}
	}
}
