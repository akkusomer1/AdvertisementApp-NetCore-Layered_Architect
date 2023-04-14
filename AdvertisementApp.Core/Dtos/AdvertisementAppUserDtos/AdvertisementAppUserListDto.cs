using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.AdvertisementApp.Core.Dtos.AdvertisementAppUserStatusDtos;
using Udemy.AdvertisementApp.Core.Dtos.AdvertisementDtos;
using Udemy.AdvertisementApp.Core.Dtos.AppUserDtos;
using Udemy.AdvertisementApp.Core.Dtos.IDto;
using Udemy.AdvertisementApp.Core.Dtos.MilitaryStatusDtos;
using Udemy.AdvertisementApp.Core.Entities;

namespace Udemy.AdvertisementApp.Core.Dtos.AdvertisementAppUserDtos
{
    public class AdvertisementAppUserListDto:IDTO
    {
        public int AdvertisementId { get; set; }
        public AdvertisementListDto Advertisement { get; set; }

        public int AppUserId { get; set; }

        public AppUserListDto AppUser { get; set; }

        public int AdvertisementAppUserStatusId { get; set; }

        public AdvertisementAppUserStatusListDto AdvertisementAppUserStatus { get; set; }

        public int MilitaryStatusId { get; set; }

        public MilitaryStatusListDto MilitaryStatus { get; set; }

        public DateTime? EndDate { get; set; }

        public int WorkExperience { get; set; }

        public string CvPath { get; set; }
    }
}
