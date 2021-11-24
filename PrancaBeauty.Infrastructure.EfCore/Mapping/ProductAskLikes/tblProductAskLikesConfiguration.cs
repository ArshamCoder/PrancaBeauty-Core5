﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PrancaBeauty.Domain.Product.ProductAskLikesAgg.Entities;
using PrancaBeauty.Infrastructure.EfCore.Contracts;

namespace PrancaBeauty.Infrastructure.EFCore.Mapping.ProductAskLikes
{
    public class tblProductAskLikesConfiguration : IEntityTypeConfiguration<tblProductAskLikes>, IEntityConf
    {
        public void Configure(EntityTypeBuilder<tblProductAskLikes> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).IsRequired().HasMaxLength(150);
            builder.Property(a => a.ProductAskId).IsRequired().HasMaxLength(150);
            builder.Property(a => a.UserId).IsRequired().HasMaxLength(450);

            builder.HasOne(a => a.tblProductAsk)
                   .WithMany(a => a.tblProductAskLikes)
                   .HasPrincipalKey(a => a.Id)
                   .HasForeignKey(a => a.ProductAskId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(a => a.tblUsers)
                   .WithMany(a => a.tblProductAskLikes)
                   .HasPrincipalKey(a => a.Id)
                   .HasForeignKey(a => a.UserId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}