using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.AdvertisementApp.Core.Dtos.IDto;

namespace Udemy.AdvertisementApp.Core.Dtos.MilitaryStatusDtos
{
    public class MilitaryStatusListDto:IDTO
    {
        public int Id { get; set; }
        public string Definition { get; set; }
    }
}
