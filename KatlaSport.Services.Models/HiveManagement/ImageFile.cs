namespace KatlaSport.Services.HiveManagement
{
    /// <summary>
    /// Image file.
    /// </summary>
    public class ImageFile
    {
        /// <summary>Gets or sets the identifier.</summary>
        /// <value>The identifier.</value>
        public int Id { get; set; }

        /// <summary>Gets or sets the name.</summary>
        /// <value>The name.</value>
        public string Name { get; set; }

        /// <summary>Gets or sets the content.</summary>
        /// <value>The content.</value>
        public byte[] Content { get; set; }

        /// <summary>
        /// Gets or sets a HiveAdmin ID.
        /// </summary>
        public int HiveAdminId { get; set; }
    }
}