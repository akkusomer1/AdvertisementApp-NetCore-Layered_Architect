using AutoMapper;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.AdvertisementApp.Core.Dtos.GenderDtos;
using Udemy.AdvertisementApp.Core.Entities;
using Udemy.AdvertisementApp.Core.Services;
using Udemy.AdvertisementApp.Core.UnitOfWork;

namespace Udemy.AdvertisementApp.Service.Services
{
    public class GenderService : GenericService<GenderCreateDto, GenderUpdateDto, GenderListDto, Gender>, IGenderService
    {
        public GenderService(IMapper mapper, IUnitOfWork unitOfWork, IValidator<GenderCreateDto> createDtoValidator, IValidator<GenderUpdateDto> updateDtoValidator) : base(mapper, unitOfWork, createDtoValidator, updateDtoValidator)
        {
        }
    }
}
