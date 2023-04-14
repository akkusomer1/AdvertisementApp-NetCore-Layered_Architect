using AutoMapper;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.AdvertisementApp.Core.Dtos.AdvertisementDtos;
using Udemy.AdvertisementApp.Core.Entities;
using Udemy.AdvertisementApp.Core.ResponseObject;
using Udemy.AdvertisementApp.Core.Services;
using Udemy.AdvertisementApp.Core.UnitOfWork;

namespace Udemy.AdvertisementApp.Service.Services
{
    public class AdvertisementService : GenericService<AdvertisementCreateDto, AdvertisementUpdateDto, AdvertisementListDto, Advertisement>, IAdvertisementService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AdvertisementService(IMapper mapper, IUnitOfWork unitOfWork, IValidator<AdvertisementCreateDto> createDtoValidator, IValidator<AdvertisementUpdateDto> updateDtoValidator) : base(mapper, unitOfWork, createDtoValidator, updateDtoValidator)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IDataGenericResponse<List<AdvertisementListDto>>> GetActivesAsync()
        {
            var values = await _unitOfWork.GetRepository<Advertisement>().GetAllAsync(x => x.Status == true, x => x.CreatedDate, Core.Enums.OrderByType.DESC);
            var newDtos = _mapper.Map<List<AdvertisementListDto>>(values);
            return new DataGenericResponse<List<AdvertisementListDto>>(ResponseType.Success, newDtos);
        }
    }
}
