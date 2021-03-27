using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PrancaBeauty.Domain.FileServer.ServerAgg.Entities;
using PrancaBeauty.Infrastructure.EfCore.Contracts;

namespace PrancaBeauty.Infrastructure.EfCore.Mapping.FileServer
{
    public class TblFileServerConfiguration : IEntityTypeConfiguration<TblFileServer>, IEntityConf
    {
        public void Configure(EntityTypeBuilder<TblFileServer> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).IsRequired().HasMaxLength(150);
            builder.Property(a => a.Name).IsRequired().HasMaxLength(100);
            builder.Property(a => a.Description).IsRequired(false);
            builder.Property(a => a.HttpDomin).IsRequired().HasMaxLength(200);
            builder.Property(a => a.HttpPath).IsRequired().HasMaxLength(250);
            builder.Property(a => a.FtpData).IsRequired();
        }
    }
}
