using AutoMapper;
using Azure;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http.HttpResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.AdvertisementApp.Core.Dtos.IDto;
using Udemy.AdvertisementApp.Core.Entities;
using Udemy.AdvertisementApp.Core.ResponseObject;
using Udemy.AdvertisementApp.Core.Services;
using Udemy.AdvertisementApp.Core.UnitOfWork;
using Udemy.AdvertisementApp.Service.Extantion;

namespace Udemy.AdvertisementApp.Service.Services
{
    public class GenericService<CreateDto, UpdateDto, ListDto, TEntity> : IGenericService<CreateDto, UpdateDto, ListDto, TEntity>
        where CreateDto : class, IDTO, new()
        where UpdateDto : class, IUpdateDto, new()
        where ListDto : class, IDTO, new()
        where TEntity : BaseEntity, new()
    {

        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator<CreateDto> _createDtoValidator;
        private readonly IValidator<UpdateDto> _updateDtoValidator;

        public GenericService(IMapper mapper, IUnitOfWork unitOfWork, IValidator<CreateDto> createDtoValidator, IValidator<UpdateDto> updateDtoValidator)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _createDtoValidator = createDtoValidator;
            _updateDtoValidator = updateDtoValidator;
        }

        public async Task<IDataGenericResponse<CreateDto>> CreateAsync(CreateDto dto)
        {

            ValidationResult result = _createDtoValidator.Validate(dto);

            if (result.IsValid)
            {
                TEntity createdEntity = _mapper.Map<TEntity>(dto);
                await _unitOfWork.GetRepository<TEntity>().CreateAsync(createdEntity);
                await _unitOfWork.CommitAsync();
                return new DataGenericResponse<CreateDto>(ResponseType.Success, dto);
            }
            return new DataGenericResponse<CreateDto>(dto, result.CustomValidationError());
        }

        public async Task<IDataGenericResponse<List<ListDto>>> GetAllAsync()
        {
            var Entites = await _unitOfWork.GetRepository<TEntity>().GetAllAsync();
            var dtos = _mapper.Map<List<ListDto>>(Entites);
            return new DataGenericResponse<List<ListDto>>(ResponseType.Success, dtos);
        }

        //GetById'de IDTo dönersek IDto'dan miras alan herhangi bir sınıfı return ile dönebiliriz.
        public async Task<IDataGenericResponse<ListDto>> GetByIdAsync(int id)
        {
            var data = await _unitOfWork.GetRepository<TEntity>().GetByFilterAsync(x => x.Id == id);
            if (data == null)
            {
                return new DataGenericResponse<ListDto>(ResponseType.NotFound, $"{id} idsine sahip data bulunamadı");

            }
            var dto = _mapper.Map<ListDto>(data);
            return new DataGenericResponse<ListDto>(ResponseType.Success, dto);
        }

        public async Task<IDataGenericResponse<IDTO>> RemoveAsync(int id)
        {
            var data = await _unitOfWork.GetRepository<TEntity>().FindAsync(id);
            if (data == null)
            {
                return new DataGenericResponse<IDTO>(ResponseType.NotFound, $"{id} idsine sahip data bulunamadı");
            }
             _unitOfWork.GetRepository<TEntity>().Remove(data);
            await _unitOfWork.CommitAsync();
            return new DataGenericResponse<IDTO>(ResponseType.Success,"Başarılı");
        }

        public async Task<IDataGenericResponse<UpdateDto>> UpdateAsync(UpdateDto dto)
        {
            var result = _updateDtoValidator.Validate(dto);
            if (result.IsValid)
            {
                var entity = _mapper.Map<TEntity>(dto);
                _unitOfWork.GetRepository<TEntity>().Update(entity);
                await _unitOfWork.CommitAsync();
                return new DataGenericResponse<UpdateDto>(ResponseType.Success, dto);
            }

            return new DataGenericResponse<UpdateDto>(dto, result.CustomValidationError());
        }
    }
}
