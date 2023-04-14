using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.AdvertisementApp.Core.Dtos.AdvertisementDtos;
using Udemy.AdvertisementApp.Core.Entities;
using Udemy.AdvertisementApp.Core.ResponseObject;

namespace Udemy.AdvertisementApp.Core.Services
{
    public interface IAdvertisementService: IGenericService<AdvertisementCreateDto,AdvertisementUpdateDto,AdvertisementListDto,Advertisement>
    {
        Task<IDataGenericResponse<List<AdvertisementListDto>>> GetActivesAsync();
    }
}
