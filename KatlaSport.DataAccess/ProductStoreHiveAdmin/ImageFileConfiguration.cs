using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace KatlaSport.DataAccess.ProductStoreHiveAdmin
{
    public class ImageFileConfiguration : EntityTypeConfiguration<ImageFile>
    {
        public ImageFileConfiguration()
        {
            HasKey(i => i.Id);
            Property(i => i.Id).HasColumnName("hiveAdmin_imageFile_id").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }
}