using FluentValidation;
using PickPoints.Core.Models;
using System.Linq;

namespace PickPoints.Core.Validators
{
    public class UpdateOrderRequestValidator : AbstractValidator<UpdateOrderRequest>
    {
        public UpdateOrderRequestValidator()
        {
            RuleFor(x => x.RecipientPhone)
                .NotNull()
                .NotEmpty()
                .Matches(@"\+7\d{3}-\d{3}-\d{2}-\d{2}")
                .WithMessage("Номер телефона должен быть в формате +7XXX-XXX-XX-XX");

            RuleFor(x => x.Goods)
                .NotNull()
                .Must(x => x.Count() <= 10)
                .WithMessage("Должно быть указано не более 10 товаров");
        }
    }
}
