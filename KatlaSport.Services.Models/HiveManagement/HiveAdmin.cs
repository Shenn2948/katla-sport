namespace KatlaSport.Services.HiveManagement
{
    /// <summary>Hive admin.</summary>
    public class HiveAdmin
    {
        /// <summary>
        /// Gets or sets a hive admin identifier.
        /// </summary>
        public int HiveAdminId { get; set; }

        /// <summary>
        /// Gets or sets a hive admin name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>Gets or sets the image file identifier.</summary>
        /// <value>The image file identifier.</value>
        public int ImageFileId { get; set; }
    }
}