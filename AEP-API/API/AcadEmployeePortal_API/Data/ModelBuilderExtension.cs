using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore;

namespace ISMS_API.Data
{
    public static class ModelBuilderExtension
    {
        public static void RemovePluralizingTableNameConvention(this ModelBuilder modelBuilder)
        {
            foreach (IMutableEntityType entity in modelBuilder.Model.GetEntityTypes())
            {
                entity.SetTableName(entity.DisplayName());
            }
        }
    }
}