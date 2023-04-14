using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.AdvertisementApp.Core.Dtos.IDto;
using Udemy.AdvertisementApp.Core.Dtos.ProvidedServiceDtos;
using Udemy.AdvertisementApp.Core.Entities;
using Udemy.AdvertisementApp.Core.ResponseObject;

namespace Udemy.AdvertisementApp.Core.Services
{
    public interface IGenericService<CreateDto, UpdateDto, ListDto, TEntity>
        where CreateDto : class, IDTO, new()
        where UpdateDto : class, IUpdateDto, new()
        where ListDto : class, IDTO, new()
        where TEntity : BaseEntity

    {
        Task<IDataGenericResponse<CreateDto>> CreateAsync(CreateDto dto);
        Task<IDataGenericResponse<UpdateDto>> UpdateAsync(UpdateDto dto);
        Task<IDataGenericResponse<ListDto>> GetByIdAsync(int id);
        Task<IDataGenericResponse<IDTO>> RemoveAsync(int id);
        Task<IDataGenericResponse<List<ListDto>>> GetAllAsync();
    }
}
