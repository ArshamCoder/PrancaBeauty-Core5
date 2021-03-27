using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PrancaBeauty.Domain.FileServer.FileAgg.Entities;
using PrancaBeauty.Infrastructure.EfCore.Contracts;

namespace PrancaBeauty.Infrastructure.EfCore.Mapping.FileServer
{
    public class TblFileConfiguration : IEntityTypeConfiguration<TblFile>, IEntityConf
    {
        public void Configure(EntityTypeBuilder<TblFile> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).IsRequired().HasMaxLength(150);
            builder.Property(a => a.FileServerId).IsRequired().HasMaxLength(150);
            builder.Property(a => a.UserId).IsRequired(false).HasMaxLength(450);
            builder.Property(a => a.Title).IsRequired().HasMaxLength(200);
            builder.Property(a => a.Path).IsRequired().HasMaxLength(250);
            builder.Property(a => a.FileName).IsRequired().HasMaxLength(200);
            builder.Property(a => a.MimeType).IsRequired().HasMaxLength(100);

            builder.HasOne(a => a.TblFileServer)
                .WithMany(a => a.TblFiles)
                .HasPrincipalKey(a => a.Id)
                .HasForeignKey(a => a.FileServerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(a => a.TblUser)
                .WithMany(a => a.TblFiles)
                .HasPrincipalKey(a => a.Id)
                .HasForeignKey(a => a.UserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
