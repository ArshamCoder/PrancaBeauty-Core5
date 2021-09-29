using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PrancaBeauty.Domain.FileServer.FileTypeAgg.Entities;
using PrancaBeauty.Infrastructure.EfCore.Contracts;

namespace PrancaBeauty.Infrastructure.EFCore.Mapping.FileServer
{
    public class tblFileTypesConfigurations : IEntityTypeConfiguration<tblFileTypes>, IEntityConf
    {
        public void Configure(EntityTypeBuilder<tblFileTypes> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).IsRequired().HasMaxLength(150);
            builder.Property(a => a.IconUrl).IsRequired().HasMaxLength(300);
            builder.Property(a => a.MimeType).IsRequired().HasMaxLength(100);
            builder.Property(a => a.Extentions).IsRequired().HasMaxLength(20);

        }
    }
}
