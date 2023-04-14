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
    public class AdvertisementConfiguration : IEntityTypeConfiguration<Advertisement>
    {
        public void Configure(EntityTypeBuilder<Advertisement> builder)
        {
            builder.Property(x=>x.Description).HasColumnType("ntext").IsRequired();
            builder.Property(x=>x.Title).HasMaxLength(200).IsRequired();
            builder.Property(x => x.CreatedDate).HasDefaultValueSql("getdate()");

            builder.HasData(new List<Advertisement>
            {
                new(){Id = 1,Title="Senior Yazılım Geliştirme Uzmanı",Description="Descpription 1",Status=true,CreatedDate=DateTime.Now},
                new(){Id = 2,Title="Middle Yazılım Geliştirme Uzmanı",Description="Descpription 2",Status=true,CreatedDate=DateTime.Now},
                new(){Id = 3,Title="Junior Yazılım Geliştirme Uzmanı",Description="Descpription 3",Status=true,CreatedDate=DateTime.Now},
                new(){Id = 4,Title="Stajyer Yazılım Geliştirme Uzmanı",Description="Descpription 4",Status=true,CreatedDate=DateTime.Now},
                new(){Id = 5,Title="Senior Mobil Yazılım Geliştirme Uzmanı",Description="Descpription 4",Status=false,CreatedDate=DateTime.Now},

            });
        }
    }
}
