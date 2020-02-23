namespace KatlaSport.DataAccess.ProductStoreHiveAdmin
{
    /// <summary>Represents a context for product store hive admins.</summary>
    /// <seealso cref="KatlaSport.DataAccess.IAsyncEntityStorage" />
    public interface IHiveAdminContext : IAsyncEntityStorage
    {
        /// <summary>Gets the hive admins.</summary>
        /// <value>The hive admins.</value>
        IEntitySet<HiveAdmin> HiveAdmins { get; }

        /// <summary>Gets the image files.</summary>
        /// <value>The image files.</value>
        IEntitySet<ImageFile> ImageFiles { get; }
    }
}