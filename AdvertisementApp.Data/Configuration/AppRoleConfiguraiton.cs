using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.AdvertisementApp.Core.Entities;

namespace Udemy.AdvertisementApp.Data.Configuration
{
    public class AppRoleConfiguraiton : IEntityTypeConfiguration<AppRole>
    {
        public void Configure(EntityTypeBuilder<AppRole> builder)
        {
           builder.Property(x=>x.RoleName).IsRequired().HasMaxLength(300);
            builder.HasData(new AppRole[]
            {
                new(){Id=1,RoleName="Admin"},
                new(){Id=2,RoleName="Member"},
            });
        }
    }
}
