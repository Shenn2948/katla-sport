using System.Threading.Tasks;

namespace KatlaSport.Services.HiveManagement
{
    /// <summary>HiveAdminImageService.</summary>
    public interface IHiveAdminImageService
    {
        /// <summary>Gets the hive admin image.</summary>
        /// <param name="id">The identifier.</param>
        /// <returns>A <see cref="Task{TResult}"/>.</returns>
        Task<ImageFile> GetHiveAdminImage(int id);

        /// <summary>Uploads the hive admin image.</summary>
        /// <param name="admin"></param>
        /// <param name="content"></param>
        /// <param name="name"></param>
        /// <returns>A <see cref="Task{TResult}"/>.</returns>
        Task<ImageFile> UploadHiveAdminImage(HiveAdmin admin, byte[] content, string name);

        /// <summary>Deletes the hive admin image.</summary>
        /// <param name="id">The identifier.</param>
        /// <returns>A <see cref="Task{TResult}"/>.</returns>
        Task DeleteHiveAdminImage(int id);
    }
}