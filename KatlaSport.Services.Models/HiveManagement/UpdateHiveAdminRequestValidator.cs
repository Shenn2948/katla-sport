using FluentValidation;

namespace KatlaSport.Services.HiveManagement
{
    /// <summary>Represents a validator for <see cref="UpdateHiveAdminRequest"/></summary>
    /// <seealso cref="FluentValidation.AbstractValidator{UpdateHiveAdminRequest}" />
    public class UpdateHiveAdminRequestValidator : AbstractValidator<UpdateHiveAdminRequest>
    {
        /// <summary>Initializes a new instance of the <see cref="UpdateHiveAdminRequestValidator"/> class.</summary>
        public UpdateHiveAdminRequestValidator()
        {
            RuleFor(r => r.Name).Length(2, 60);
        }
    }
}