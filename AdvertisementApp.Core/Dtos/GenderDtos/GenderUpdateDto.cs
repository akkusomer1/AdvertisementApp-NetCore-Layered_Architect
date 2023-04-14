using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.AdvertisementApp.Core.Dtos.IDto;

namespace Udemy.AdvertisementApp.Core.Dtos.GenderDtos
{
    public class GenderUpdateDto:IUpdateDto
    {
        public int Id { get; set; }
        public string Defination { get; set; }
    }
}
