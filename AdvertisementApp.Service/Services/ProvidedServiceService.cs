using AutoMapper;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.AdvertisementApp.Core.Dtos.ProvidedServiceDtos;
using Udemy.AdvertisementApp.Core.Entities;
using Udemy.AdvertisementApp.Core.Services;
using Udemy.AdvertisementApp.Core.UnitOfWork;

namespace Udemy.AdvertisementApp.Service.Services
{
    public class ProvidedServiceService : GenericService<ProvidedServiceCreateDto, ProvidedServiceUpdateDto, ProvidedServiceListDto, ProvidedService>, IProvidedServiceService
    {
        //Aynı zamanda base class'tan gelen constructor içefisindeki değerleri bu class'tan göndermemi istiyor.
        public ProvidedServiceService(IMapper mapper, IUnitOfWork unitOfWork, IValidator<ProvidedServiceCreateDto> createDtoValidator, IValidator<ProvidedServiceUpdateDto> updateDtoValidator) : base(mapper, unitOfWork, createDtoValidator, updateDtoValidator)
        {
        }
    }
}
