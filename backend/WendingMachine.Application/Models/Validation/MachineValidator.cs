using FluentValidation;
using WendingMachine.Application.Models.DTOs;

namespace WendingMachine.Application.Models.Validation
{
    public class MachineValidator : AbstractValidator<MachineDTO>
    {
        public MachineValidator()
        {
            this.RuleFor(dto => dto.Balance).NotNull().WithMessage("Обязательное поле");
            this.RuleForEach(dto => dto.Drinks).SetValidator(new DrinkValidator());
        }
    }
}
