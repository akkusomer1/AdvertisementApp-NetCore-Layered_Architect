using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Udemy.AdvertisementApp.Core.Entities;

namespace Udemy.AdvertisementApp.Data.Configuration
{
    public class ProvidedServiceConfiguration : IEntityTypeConfiguration<ProvidedService>
    { 
        public void Configure(EntityTypeBuilder<ProvidedService> builder)
        {
            builder.Property(x => x.Description).HasColumnType("ntext").IsRequired();
            builder.Property(x => x.ImagePath).HasMaxLength(500).IsRequired();
            builder.Property(x => x.Title).HasMaxLength(300).IsRequired();
            builder.Property(x => x.CreatedDate).HasDefaultValueSql("getdate()");

            builder.HasData(
                new List<ProvidedService>()
                {
                    new ProvidedService(){Id=2,Description="Web Uygulaması Descpription",Title="Web Uygulaması",ImagePath="/images/01.jpg"},
                    new ProvidedService(){Id=3,Description="Pc Uygulaması Descpription",Title="Pc Uygulaması",ImagePath="/images/02.jpg"},
                    new ProvidedService(){Id=4,Description="Mobil Uygulaması Descpription",Title="Mobil Uygulaması",ImagePath="/images/03.jpg"},
                });
        }
    }
}
