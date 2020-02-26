using System.ComponentModel.DataAnnotations.Schema;
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
            HasKey(i => i.Id);
            Property(i => i.Id).HasColumnName("hiveAdmin_id").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            HasMany(x => x.StoreHives).WithOptional(x => x.HiveAdmin).HasForeignKey(x => x.HiveAdminId);
            HasOptional(x => x.ImageFile);
        }
    }
}