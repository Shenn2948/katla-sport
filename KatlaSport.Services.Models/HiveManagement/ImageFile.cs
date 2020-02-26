namespace KatlaSport.Services.HiveManagement
{
    /// <summary>
    /// Image file.
    /// </summary>
    public class ImageFile
    {
        /// <summary>Gets or sets the name.</summary>
        /// <value>The name.</value>
        public string Name { get; set; }

        /// <summary>Gets or sets the content.</summary>
        /// <value>The content.</value>
        public string Content { get; set; }

        /// <summary>Gets or sets the hive admin identifier.</summary>
        /// <value>The hive admin identifier.</value>
        public int HiveAdminId { get; set; }
    }
}