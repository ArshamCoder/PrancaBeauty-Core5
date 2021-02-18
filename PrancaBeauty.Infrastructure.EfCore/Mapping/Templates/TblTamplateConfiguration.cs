using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PrancaBeauty.Domain.TemplateAgg.Entities;
using PrancaBeauty.Infrastructure.EfCore.Contracts;

namespace PrancaBeauty.Infrastructure.EfCore.Mapping.Templates
{
    public class TblTamplateConfiguration : IEntityTypeConfiguration<TblTemplate>, IEntityConf
    {
        public void Configure(EntityTypeBuilder<TblTemplate> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).IsRequired().HasMaxLength(150);
            builder.Property(a => a.LangId).IsRequired().HasMaxLength(150);
            builder.Property(a => a.Name).IsRequired().HasMaxLength(100);
            builder.Property(a => a.Template).IsRequired();

            builder.HasOne(x => x.Language)
                .WithMany(x => x.TblTemplates)
                .HasPrincipalKey(x => x.Id)
                .HasForeignKey(x => x.LangId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
