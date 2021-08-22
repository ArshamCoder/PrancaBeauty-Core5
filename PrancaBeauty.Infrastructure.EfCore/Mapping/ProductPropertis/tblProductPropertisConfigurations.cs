﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PrancaBeauty.Domain.Product.ProductPropertisAgg.Entities;
using PrancaBeauty.Infrastructure.EfCore.Contracts;

namespace PrancaBeauty.Infrastructure.EFCore.Mapping.ProductPropertis
{
    public class tblProductPropertisConfigurations : IEntityTypeConfiguration<tblProductPropertis>, IEntityConf
    {
        public void Configure(EntityTypeBuilder<tblProductPropertis> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).IsRequired().HasMaxLength(150);
            builder.Property(a => a.TopicId).IsRequired().HasMaxLength(150);
            builder.Property(a => a.Name).IsRequired().HasMaxLength(200);

            builder.HasOne(a => a.tblProductTopic)
                   .WithMany(a => a.tblProductPropertis)
                   .HasPrincipalKey(a => a.Id)
                   .HasForeignKey(a => a.TopicId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
