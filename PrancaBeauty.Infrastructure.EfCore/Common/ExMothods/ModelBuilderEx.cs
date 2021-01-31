using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace PrancaBeauty.Infrastructure.EfCore.Common.ExMothods
{
    public static class ModelBuilderEx
    {
        public static void RegisterEntityTypeConfiguration(this ModelBuilder modelBuilder, params Assembly[] assemblies)
        {

        }
    }
}
