using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Udemy.AdvertisementApp.Core.Entities
{
    public class Gender:BaseEntity
    {
        public string Defination { get; set; }
        public List<AppUser> AppUsers { get; set; }
    }
}
