﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.AdvertisementApp.Core.Entities;

namespace Udemy.AdvertisementApp.Data.Configuration
{
    public class AppUserRoleConfiguration : IEntityTypeConfiguration<AppUserRole>
    {
        public void Configure(EntityTypeBuilder<AppUserRole> builder)
        {
            builder.HasIndex(x => new { x.UserId, x.RoleId }).IsUnique();
            builder.HasOne(x=>x.AppUser).WithMany(x=>x.UserRoles).HasForeignKey(x=>x.UserId);
            builder.HasOne(x=>x.AppRole).WithMany(x=>x.UserRoles).HasForeignKey(x=>x.RoleId);
        }
    }
}
