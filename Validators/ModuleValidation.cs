using CustomerModules.ViewModels;
using FluentValidation;
using System;

namespace CustomerModules.Validators
{
    public class ModuleValidation : AbstractValidator<AddModuleViewModel>
    {
        public ModuleValidation()
        {
            RuleFor(vm => vm.Module)
                .NotEmpty()
                .WithMessage("Es muss ein Modul ausgewählt sein.");
            var comparisonDate = new DateTime(1980, 1, 1);
            RuleFor(vm => vm.ActivationDate)
                .GreaterThan(comparisonDate)
                .WithMessage("Das Datum muss nach 1980 liegen.")
                .NotEmpty()
                .WithMessage("Es muss ein Datum angegenen werden.");
        }
    }
}
