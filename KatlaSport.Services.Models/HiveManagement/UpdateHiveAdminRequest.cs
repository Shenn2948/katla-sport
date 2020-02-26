using FluentValidation.Attributes;

namespace KatlaSport.Services.HiveManagement
{
    /// <summary>Update hive admin request.</summary>
    [Validator(typeof(UpdateHiveAdminRequestValidator))]
    public class UpdateHiveAdminRequest
    {
        /// <summary>
        /// Gets or sets a store hive admin name.
        /// </summary>
        public string Name { get; set; }
    }
}