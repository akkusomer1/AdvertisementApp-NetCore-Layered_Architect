using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.AdvertisementApp.Core.Dtos.IDto;

namespace Udemy.AdvertisementApp.Core.Dtos.AppUserDtos
{
    public class AppUserLogInDto:IDTO
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
