using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PrancaBeauty.Domain.Keywords.KeywordAgg.Entities;
using PrancaBeauty.Infrastructure.EfCore.Contracts;

namespace PrancaBeauty.Infrastructure.EFCore.Mapping.Keywords
{
    public class tblKeywordConfiguration : IEntityTypeConfiguration<tblKeywords>, IEntityConf
    {
        public void Configure(EntityTypeBuilder<tblKeywords> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).IsRequired().HasMaxLength(150);
            builder.Property(a => a.Name).IsRequired().HasMaxLength(250);
            builder.Property(a => a.Title).IsRequired().HasMaxLength(250);
            builder.Property(a => a.Description).IsRequired();
        }
    }
}
