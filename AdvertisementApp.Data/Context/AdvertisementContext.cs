﻿using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Udemy.AdvertisementApp.Core.Entities;
using Udemy.AdvertisementApp.Data.Configuration;

namespace Udemy.AdvertisementApp.Data.Context
{
    public class AdvertisementContext:DbContext
    {
        public AdvertisementContext(DbContextOptions<AdvertisementContext> options):base(options)
        {

        }

        public DbSet<Advertisement> Advertisements { get; set; }
        public DbSet<AdvertisementAppUser> AdvertisementAppUsers { get; set; }

        public DbSet<AdvertisementAppUserStatus> AdvertisementAppUserStatuses { get; set; }

        public DbSet<AppRole> AppRoles { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }

        public DbSet<AppUserRole> AppUserRoles { get; set; }

        public DbSet<Gender> Genders { get; set; }

        public DbSet<MilitaryStatus> MilitaryStatuses { get; set; }

        public DbSet<ProvidedService> ProvidedServices { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
         
            base.OnModelCreating(modelBuilder);
        }
    }
}
