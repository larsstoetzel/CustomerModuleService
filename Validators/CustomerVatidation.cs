using CustomerModules.ViewModels;
using FluentValidation;
using System;

namespace CustomerModules.Validators
{
    public class CustomerValidation : AbstractValidator<CreateEditCustomerViewModel>
    {
        public CustomerValidation()
        {
            RuleFor(vm => vm.Name)
                .NotEmpty()
                .WithMessage("Feld darf nicht leer sein");
            RuleFor(vm => vm.City)
                .NotEmpty()
                .WithMessage("Feld darf nicht leer sein");
            RuleFor(vm => vm.Url)
                .NotEmpty()
                .Must(url => Uri.TryCreate(url, UriKind.Absolute, out Uri uriResult)
                && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps))
                .WithMessage("Die URL muss eine gültige HTTP- oder HTTPS-URL sein.");
            RuleFor(vm => vm.PortalUrl)
                .NotEmpty()
                .Must(url => Uri.TryCreate(url, UriKind.Absolute, out Uri uriResult)
                && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps))
                .WithMessage("Die URL muss eine gültige HTTP- oder HTTPS-URL sein.");
            RuleFor(vm => vm.Modules)
                .NotEmpty()
                .WithMessage("Es muss mindestens ein Modul hinzugefügt werden");
        }

    }
}
