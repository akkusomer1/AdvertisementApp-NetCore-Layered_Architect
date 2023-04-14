using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.AdvertisementApp.Core.Dtos.AdvertisementAppUserDtos;
using Udemy.AdvertisementApp.Core.Enums;
using Udemy.AdvertisementApp.Core.ResponseObject;
using Udemy.AdvertisementApp.Core.UnitOfWork;

namespace Udemy.AdvertisementApp.Core.Services
{
    public interface IAdvertisementAppUserService                                           
    {
        Task SetStatus(int advertisementId, AdvertisementAppUserStatusType type);
        Task<List<AdvertisementAppUserListDto>> GetList(AdvertisementAppUserStatusType type);
        Task<IDataGenericResponse<AdvertisementAppUserCreateDto>> CreateASync(AdvertisementAppUserCreateDto dto);
    }
}
