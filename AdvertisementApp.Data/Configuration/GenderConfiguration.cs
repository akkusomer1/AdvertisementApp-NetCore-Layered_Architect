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
    public class GenderConfiguration : IEntityTypeConfiguration<Gender>
    {
        public void Configure(EntityTypeBuilder<Gender> builder)
        {
            builder.Property(x => x.Defination).HasMaxLength(300).IsRequired();

            builder.HasData(
                new List<Gender>
                {
                    new(){Id=1 ,Defination="Erkek"},
                    new(){Id=2 ,Defination="Kadın"}
                });
        }
    }
}
