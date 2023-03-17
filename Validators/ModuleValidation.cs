using CustomerModules.ViewModels;
using FluentValidation;

namespace CustomerModules.Validators
{
    public class ModuleValidation : AbstractValidator<AddModuleViewModel>
    {
        public ModuleValidation()
        {
            RuleFor(vm => vm.Module)
                .NotEmpty()
                .WithMessage("Es muss ein Modul ausgewählt sein.");
            RuleFor(vm => vm.ActivationDate)
                .NotEmpty()
                .WithMessage("Es muss ein Datum angegenen werden.");
        }
    }
}
