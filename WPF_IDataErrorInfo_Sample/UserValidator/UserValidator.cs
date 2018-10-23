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
                .NotEmpty().WithMessage("Must be not empty")
                .Length(5).WithMessage("Not equal 5");


            RuleFor(user => user.Email)
                .NotEmpty().WithMessage("Must be not empty")
                .EmailAddress().WithMessage("Please Specify a Valid E-Mail Address");

            RuleFor(user => user.Zip)
                .NotEmpty().WithMessage("Must be not empty")
                .MaximumLength(5).WithMessage("Please Enter a Valid Zip Code")
                .Must(BeAValidZip).WithMessage("Please Enter a Valid Zip Code");


        }

        private static bool BeAValidZip(string zip)
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