using FluentValidation;
using WendingMachine.Application.Models.DTOs;

namespace WendingMachine.Application.Models.Validation
{
    public class DrinkValidator : AbstractValidator<DrinkDTO>
    {
        public DrinkValidator()
        {
            this.RuleFor(dto => dto.Name).NotNull().NotEmpty().WithMessage("Обязательное поле");
            this.RuleFor(dto => dto.Price).NotNull().GreaterThan(0).WithMessage("Цена должна быть больше 0");
            this.RuleFor(dto => dto.Count).NotNull().GreaterThan(0).WithMessage("Количество должно быть больше 0");
            this.RuleFor(dto => dto.isAvailable).NotNull().WithMessage("Обязательное поле");
        }
    }
}
