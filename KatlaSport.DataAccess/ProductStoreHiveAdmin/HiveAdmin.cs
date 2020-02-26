using System.Collections.Generic;
using KatlaSport.DataAccess.ProductStoreHive;

namespace KatlaSport.DataAccess.ProductStoreHiveAdmin
{
    /// <summary>HiveAdmin.</summary>
    public class HiveAdmin
    {
        /// <summary>Gets or sets the identifier.</summary>
        /// <value>The identifier.</value>
        public int HiveAdminId { get; set; }

        /// <summary>Gets or sets the name.</summary>
        /// <value>The name.</value>
        public string Name { get; set; }

        /// <summary>Gets or sets the image file identifier.</summary>
        /// <value>The image file identifier.</value>
        public int ImageFileId { get; set; }

        /// <summary>Gets or sets the image file.</summary>
        /// <value>The image file.</value>
        public virtual ImageFile ImageFile { get; set; }

        /// <summary>
        /// Gets or sets a collection of store hives.
        /// </summary>
        public virtual ICollection<StoreHive> StoreHives { get; set; }
    }
}