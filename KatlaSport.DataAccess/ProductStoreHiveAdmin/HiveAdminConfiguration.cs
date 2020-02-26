using System.Data.Entity.ModelConfiguration;

namespace KatlaSport.DataAccess.ProductStoreHiveAdmin
{
    /// <summary>The <see cref="HiveAdminConfiguration"/> class.</summary>
    /// <seealso cref="System.Data.Entity.ModelConfiguration.EntityTypeConfiguration{HiveAdmin}" />
    public class HiveAdminConfiguration : EntityTypeConfiguration<HiveAdmin>
    {
        /// <summary>Initializes a new instance of the <see cref="HiveAdminConfiguration"/> class.</summary>
        public HiveAdminConfiguration()
        {
            HasMany(x => x.StoreHives).WithOptional(x => x.HiveAdmin).HasForeignKey(x => x.HiveAdminId);
            HasOptional(x => x.ImageFile).WithRequired(x => x.HiveAdmin);
        }
    }
}