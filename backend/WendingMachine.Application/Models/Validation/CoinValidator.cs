using FluentValidation;
using WendingMachine.Application.Models.DTOs;

namespace WendingMachine.Application.Models.Validation
{
    public class CoinValidator : AbstractValidator<CoinDTO>
    {
        public CoinValidator()
        {
            this.RuleFor(dto => dto.Denomination).NotNull().NotEmpty().GreaterThan(0).WithMessage("Обязательное поле");
            this.RuleFor(dto => dto.isAvailable).NotNull().WithMessage("Обязательное поле");
        }
    }
}
