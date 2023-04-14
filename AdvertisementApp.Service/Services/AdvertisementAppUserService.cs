using AutoMapper;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Udemy.AdvertisementApp.Core.Dtos.AdvertisementAppUserDtos;
using Udemy.AdvertisementApp.Core.Entities;
using Udemy.AdvertisementApp.Core.Enums;
using Udemy.AdvertisementApp.Core.ResponseObject;
using Udemy.AdvertisementApp.Core.Services;
using Udemy.AdvertisementApp.Core.UnitOfWork;
using Udemy.AdvertisementApp.Service.Extantion;

namespace Udemy.AdvertisementApp.Service.Services
{
    public class AdvertisementAppUserService : IAdvertisementAppUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IValidator<AdvertisementAppUserCreateDto> _validator;

        public AdvertisementAppUserService(IUnitOfWork unitOfWork, IMapper mapper, IValidator<AdvertisementAppUserCreateDto> validator)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<IDataGenericResponse<AdvertisementAppUserCreateDto>> CreateASync(AdvertisementAppUserCreateDto dto)
        {
            var result = _validator.Validate(dto);

            if (result.IsValid)
            {

                var control = await _unitOfWork.GetRepository<AdvertisementAppUser>().GetByFilterAsync(x => x.AppUserId == dto.AppUserId && x.AdvertisementId == dto.AdvertisementId);

                if (control == null)
                {
                    var entity = _mapper.Map<AdvertisementAppUser>(dto);

                    await _unitOfWork.GetRepository<AdvertisementAppUser>().CreateAsync(entity);
                    await _unitOfWork.CommitAsync();

                    return new DataGenericResponse<AdvertisementAppUserCreateDto>(ResponseType.Success, dto);
                }

                return new DataGenericResponse<AdvertisementAppUserCreateDto>(ResponseType.ValidationError, "Daha önce başvurulan ilana başvurulamaz.");
            }
            return new DataGenericResponse<AdvertisementAppUserCreateDto>(dto, result.CustomValidationError());
        }


        //List AdvertisementAppUserListDto döneceğim.
        public async Task<List<AdvertisementAppUserListDto>> GetList(AdvertisementAppUserStatusType type)
        {
            var query = _unitOfWork.GetRepository<AdvertisementAppUser>().GetQuery();

            var list = await query
                .Include(x => x.AppUser).ThenInclude(x => x.Gender)
                .Include(x => x.Advertisement)
                .Include(x => x.AdvertisementAppUserStatus)
                .Include(x => x.MilitaryStatus)
                .Where(x => x.AdvertisementAppUserStatusId == (int)type).ToListAsync();

            List<AdvertisementAppUserListDto> listDto = _mapper.Map<List<AdvertisementAppUserListDto>>(list);

            return listDto;
        }

        //GenericRepostiyory'de update kısmında unchanged kısmını kaldırdım.
        //advertisementId değerinden ilana başvuru ıd'sinden bulup StatusId'sini değiştirdim.
        //Hatta AdvertisementAppUserListDto döndürmüyorum direk task döndürüyorum.
        public async Task SetStatus(int advertisementId, AdvertisementAppUserStatusType type)
        {
           var advertisementAppUser=  await _unitOfWork.GetRepository<AdvertisementAppUser>().GetByFilterAsync(x => x.AdvertisementId == advertisementId);
            advertisementAppUser.AdvertisementAppUserStatusId =(int) type;
            _unitOfWork.GetRepository<AdvertisementAppUser>().Update(advertisementAppUser);
           await _unitOfWork.CommitAsync();
        }


    }
}
