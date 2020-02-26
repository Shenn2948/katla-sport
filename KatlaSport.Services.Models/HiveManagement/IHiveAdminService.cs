using System.Collections.Generic;
using System.Threading.Tasks;

namespace KatlaSport.Services.HiveManagement
{
    /// <summary>Hive admin service.</summary>
    public interface IHiveAdminService
    {
        /// <summary>
        /// Gets a list of hive admin sections.
        /// </summary>
        /// <returns>A <see cref="Task{TResult}"/>.</returns>
        Task<List<HiveAdmin>> GetHiveAdminsAsync();

        /// <summary>
        /// Gets a hive admin section.
        /// </summary>
        /// <param name="id">A hive admin section identifier.</param>
        /// <returns>A <see cref="Task{HiveAdmin}"/>.</returns>
        Task<HiveAdmin> GetHiveAdminAsync(int id);

        /// <summary>
        /// Creates a new hive admin.
        /// </summary>
        /// <param name="createRequest">A <see cref="UpdateHiveAdminRequest"/>.</param>
        /// <returns>A <see cref="Task{HiveAdmin}"/>.</returns>
        Task<HiveAdmin> CreateHiveAdminAsync(UpdateHiveAdminRequest createRequest);

        /// <summary>
        /// Updates an existed hive admin.
        /// </summary>
        /// <param name="hiveAdminId">A hive admin identifier.</param>
        /// <param name="updateRequest">A <see cref="UpdateHiveAdminRequest"/>.</param>
        /// <returns>A <see cref="Task{HiveAdmin}"/>.</returns>
        Task<HiveAdmin> UpdateHiveAdminAsync(int hiveAdminId, UpdateHiveAdminRequest updateRequest);

        /// <summary>
        /// Deletes an existed hive admin.
        /// </summary>
        /// <param name="hiveAdminId">A hive admin identifier.</param>
        /// <returns>A <see cref="Task"/>.</returns>
        Task DeleteHiveAdminAsync(int hiveAdminId);

        /// <summary>
        /// Updates an existed hive admin.
        /// </summary>
        /// <param name="image">A <see cref="ImageFile"/>.</param>
        /// <returns>A <see cref="Task{HiveAdmin}"/>.</returns>
        Task UpdateHiveAdminImageAsync(ImageFile image);
    }
}