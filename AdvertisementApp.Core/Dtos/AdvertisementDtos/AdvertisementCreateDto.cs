using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.AdvertisementApp.Core.Dtos.IDto;

namespace Udemy.AdvertisementApp.Core.Dtos.AdvertisementDtos
{
    public class AdvertisementCreateDto : IDTO
    {
        public string Title { get; set; }
        public bool Status { get; set; }
        public string Description { get; set; }
    }
}
