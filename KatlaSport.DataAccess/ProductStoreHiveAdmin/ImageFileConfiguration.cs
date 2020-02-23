using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace KatlaSport.DataAccess.ProductStoreHiveAdmin
{
    public class ImageFileConfiguration: EntityTypeConfiguration<ImageFile>
    {
        public ImageFileConfiguration()
        {
            ToTable("product_store_hive_admin_image_files");
            HasKey(i => i.Id);
            Property(i => i.Id).HasColumnName("product_store_hive_admin_image_file_id").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(i => i.Name).HasColumnName("product_store_hive_admin_image_file_name").HasMaxLength(60).IsRequired();
            Property(i => i.Content).HasColumnName("product_store_hive_admin_image_file_content");
            HasRequired(i => i.HiveAdmin).WithOptional(i => i.ImageFile);
        }
    }
}