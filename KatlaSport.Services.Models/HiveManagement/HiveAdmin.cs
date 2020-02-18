﻿
namespace KatlaSport.Services.HiveManagement
{
    /// <summary>Hive admin.</summary>
    public class HiveAdmin
    {
        /// <summary>
        /// Gets or sets a hive admin identifier.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets a hive admin name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether a hive admin is deleted.
        /// </summary>
        public bool IsDeleted { get; set; }
    }
}