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
            ToTable("product_store_hive_admins");
            HasKey(i => i.Id);
            Property(i => i.Id).HasColumnName("product_store_hive_admin_id").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(i => i.Name).HasColumnName("product_store_hive_admin_name").HasMaxLength(60).IsRequired();
            HasOptional(i => i.ImageFile).WithRequired(i => i.HiveAdmin);
        }
    }
}