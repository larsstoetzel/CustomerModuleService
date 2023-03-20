using CustomerModules.Models;
using CustomerModules.ViewModels;
using FluentValidation;
using System;
using System.Linq;

namespace CustomerModules.Validators
{
    public class CustomerValidation : AbstractValidator<CreateEditCustomerViewModel>
    {
        private readonly CustomerContext _context;

        public CustomerValidation(CustomerContext context)
        {
            _context = context;
            RuleFor(c => c.Name)
           .NotEmpty()
           .Must(BeUniqueName)
           .WithMessage("Kunde ist bereits vorhanden")
           .When(c => !_context.Customers.Any(cust => cust.CustomerId == (c.CustomerId ?? 0) && c.CustomerId != null));
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
                .Must(modules => modules != null && modules.Any())
                .WithMessage("Es muss mindestens ein Modul hinzugefügt werden");
            RuleFor(x => x.SelectedCity)
                .Must((model, selectedValue) => model.Cities.Contains(selectedValue))
                .WithMessage("Eine gültigen Ort angeben.");
        }

        private bool BeUniqueName(string name)
        {
            return !_context.Customers.Any(c => c.Name == name);
        }
    }
}
