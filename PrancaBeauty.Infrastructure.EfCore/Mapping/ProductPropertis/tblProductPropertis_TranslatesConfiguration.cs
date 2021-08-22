using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PrancaBeauty.Domain.Product.ProductPropertisAgg.Entities;
using PrancaBeauty.Infrastructure.EfCore.Contracts;

namespace PrancaBeauty.Infrastructure.EFCore.Mapping.ProductPropertis
{
    public class tblProductPropertis_TranslatesConfiguration : IEntityTypeConfiguration<tblProductPropertis_Translates>, IEntityConf
    {
        public void Configure(EntityTypeBuilder<tblProductPropertis_Translates> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).IsRequired().HasMaxLength(150);
            builder.Property(a => a.PropertyId).IsRequired().HasMaxLength(150);
            builder.Property(a => a.LangId).IsRequired().HasMaxLength(150);
            builder.Property(a => a.Title).IsRequired().HasMaxLength(150);

            builder.HasOne(a => a.tblProductPropertis)
                   .WithMany(a => a.tblProductPropertis_Translates)
                   .HasPrincipalKey(a => a.Id)
                   .HasForeignKey(a => a.PropertyId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(a => a.tblLanguages)
                   .WithMany(a => a.tblProductPropertis_Translates)
                   .HasPrincipalKey(a => a.Id)
                   .HasForeignKey(a => a.LangId)
                   .OnDelete(DeleteBehavior.Restrict);
        }

    }
}
