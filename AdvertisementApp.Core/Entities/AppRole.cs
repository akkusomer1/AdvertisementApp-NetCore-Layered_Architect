using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Udemy.AdvertisementApp.Core.Entities
{
    public class AppRole:BaseEntity
    {
        public string RoleName { get; set; }

        public List<AppUserRole> UserRoles { get; set; }
    }
}
