using System.Text.RegularExpressions;
using FluentValidation;
using WPF_IDataErrorInfo_Sample.ViewModels;

namespace WpfFluentValidationExample.Lib
{
    public class UserValidator : AbstractValidator<UserViewModel>
    {
        public UserValidator()
        {
            RuleFor(user => user.Name)
                .NotEmpty().WithMessage("Mustn't be empty")
                .Length(5).WithMessage("Not equal 5");

            RuleFor(user => user.Email)
                .NotEmpty().WithMessage("Mustn't be empty")
                .EmailAddress().WithMessage("Please Specify a Valid E-Mail Address");

            RuleFor(user => user.Zip)
                .NotEmpty().WithMessage("Mustn't be empty")
                .Must(ValidZip).WithMessage("Not valid Zip code");
            RuleFor(user => user.Age)
                .NotEmpty().WithMessage("Mustn't be empty")
                .LessThan(100).WithMessage("Must be less then 100")
                .GreaterThan(18).WithMessage("Must be greater then 18");
        }

        private static bool ValidZip(string zip)
        {
            if (!string.IsNullOrEmpty(zip))
            {
                var regex = new Regex(@"\d{5}");
                return regex.IsMatch(zip);
            }
            return false;
        }
    }
}