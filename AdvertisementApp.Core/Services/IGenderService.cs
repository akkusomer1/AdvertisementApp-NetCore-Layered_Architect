using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.AdvertisementApp.Core.Dtos.GenderDtos;
using Udemy.AdvertisementApp.Core.Entities;

namespace Udemy.AdvertisementApp.Core.Services
{
    public interface IGenderService:IGenericService<GenderCreateDto,GenderUpdateDto,GenderListDto,Gender>
    {
    }
}
