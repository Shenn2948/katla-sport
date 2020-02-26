
using System.ComponentModel.DataAnnotations.Schema;

namespace KatlaSport.DataAccess.ProductStoreHiveAdmin
{
    public class ImageFile
    {
        /// <summary>Gets or sets the hive admin identifier.</summary>
        /// <value>The hive admin identifier.</value>
        [ForeignKey(nameof(HiveAdmin))]
        public int ImageFileId { get; set; }

        /// <summary>Gets or sets the name.</summary>
        /// <value>The name.</value>
        public string Name { get; set; }

        /// <summary>Gets or sets the content.</summary>
        /// <value>The content.</value>
        public string Content { get; set; }

        /// <summary>Gets or sets the hive admin.</summary>
        /// <value>The hive admin.</value>
        public virtual HiveAdmin HiveAdmin { get; set; }
    }
}