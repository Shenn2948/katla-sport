using System;

namespace KatlaSport.Services.HiveManagement
{
    /// <summary>Hive admin list item.</summary>
    /// <seealso cref="KatlaSport.Services.HiveManagement.HiveAdmin" />
    public class HiveAdminListItem : HiveAdmin
    {
        /// <summary>
        /// Gets or sets a timestamp when the hive admin was updated last time.
        /// </summary>
        public DateTime LastUpdated { get; set; }
    }
}