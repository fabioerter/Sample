using FluentValidation;
using $ext_projectname$.Domain.Entities;

namespace $safeprojectname$.Validations
{
    public class PersonSampleValidator : AbstractValidator<PersonSample>
    {
        public PersonSampleValidator()
        {
            ValidateId();
            ValidateFullName();
            ValidateDateBirth();
            ValidateAge();

            RuleSet("Insert", () =>
            {
                ValidateFullName();
                ValidateDateBirth();
                ValidateAge();
            });

            RuleSet("Update", () =>
            {
                ValidateId();
                ValidateFullName();
                ValidateDateBirth();
                ValidateAge();
            });
        }

        private void ValidateId()
        {
            RuleFor(o => o.Id).NotEmpty().WithMessage(Resources.Validations.PersonSampleIdRequired);
        }

        private void ValidateFullName()
        {
            RuleFor(o => o.FullName)
                .NotEmpty().WithMessage(Resources.Validations.PersonSampleFullNameRequired)
                .Length(1, 100).WithMessage(Resources.Validations.PersonSampleFullNameLength);
        }

        private void ValidateDateBirth()
        {
            RuleFor(o => o.DateBirth)
                .NotEmpty().WithMessage(Resources.Validations.PersonSampleDateBirthRequired);
        }

        private void ValidateAge()
        {
            RuleFor(o => o.Age)
                .NotEmpty().WithMessage(Resources.Validations.PersonSampleAgeRequired);
        }
    }
}
