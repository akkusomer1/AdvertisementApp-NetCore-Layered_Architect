﻿using Udemy.AdvertisementApp.Core.Enums;

namespace Udemy.AdvertisementApp.UI.Models
{
    public class AdvertisementAppUserCreateVm
    {
        public int AdvertisementId { get; set; }
        public int AppUserId { get; set; }

        public int AdvertisementAppUserStatusId { get; set; } = (int)AdvertisementAppUserStatusType.Başvurdu;

        public int MilitaryStatusId { get; set; }

        public DateTime? EndDate { get; set; }

        public int WorkExperience { get; set; }

        public IFormFile CvFile { get; set; }
    }
}
