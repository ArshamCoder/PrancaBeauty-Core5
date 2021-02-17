using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PrancaBeauty.Domain.Template.Entities;
using PrancaBeauty.Infrastructure.EfCore.Contracts;

namespace PrancaBeauty.Infrastructure.EfCore.Mapping.Templates
{
    public class TblTamplateConfiguration : IEntityTypeConfiguration<TblTemplate>, IEntityConf
    {
        public void Configure(EntityTypeBuilder<TblTemplate> builder)
        {

        }
    }
}
