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
            builder.Property(a => a.FilePathId).IsRequired().HasMaxLength(150);
            builder.Property(a => a.FileTypeId).IsRequired().HasMaxLength(150);
            builder.Property(a => a.UserId).IsRequired(false).HasMaxLength(450);
            builder.Property(a => a.Title).IsRequired().HasMaxLength(200);
            builder.Property(a => a.FileName).IsRequired().HasMaxLength(200);

            builder.HasOne(a => a.tblFilePaths)
                .WithMany(a => a.tblFiles)
                .HasPrincipalKey(a => a.Id)
                .HasForeignKey(a => a.FilePathId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(a => a.tblUser)
                .WithMany(a => a.tblFiles)
                .HasPrincipalKey(a => a.Id)
                .HasForeignKey(a => a.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(a => a.tblFileTypes)
                .WithMany(a => a.tblFiles)
                .HasPrincipalKey(a => a.Id)
                .HasForeignKey(a => a.FileTypeId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
