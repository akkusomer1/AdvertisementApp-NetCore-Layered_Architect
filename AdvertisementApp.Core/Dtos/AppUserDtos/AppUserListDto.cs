using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using Udemy.AdvertisementApp.Core.Dtos.GenderDtos;
using Udemy.AdvertisementApp.Core.Dtos.IDto;
using Udemy.AdvertisementApp.Core.Entities;

namespace Udemy.AdvertisementApp.Core.Dtos.AppUserDtos
{
    public class AppUserListDto:IDTO
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Surname { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int GenderId { get; set; }
        public GenderListDto Gender { get; set; }
        public string PhoneNumber { get; set; }
    }
}
