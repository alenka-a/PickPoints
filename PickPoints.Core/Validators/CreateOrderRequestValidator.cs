using FluentValidation;
using PickPoints.Core.Models;
using System.Linq;

namespace PickPoints.Core.Validators
{
    public class CreateOrderRequestValidator : AbstractValidator<CreateOrderRequest>
    {
        public CreateOrderRequestValidator()
        {
            // TODO Вынести общую логику по проверке полей
            RuleFor(x => x.RecipientPhone)
                .NotNull()
                .NotEmpty()
                .Matches(@"\+7\d{3}-\d{3}-\d{2}-\d{2}")
                .WithMessage("Номер телефона должен быть в формате +7XXX-XXX-XX-XX");

            RuleFor(x => x.PostampNumber)
                .NotNull()
                .NotEmpty()
                .Matches(@"\d{4}-\d{3}")
                .WithMessage("Номер постамата должен быть в формате XXXX-XXX");

            RuleFor(x => x.Goods)
                .NotNull()
                .Must(x => x != null && x.Count() <= 10 && x.Count() > 0)
                .WithMessage("Должно быть указано не более 10 товаров");
        }
    }
}
