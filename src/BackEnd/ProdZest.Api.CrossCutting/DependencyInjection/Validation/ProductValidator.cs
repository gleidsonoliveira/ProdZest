using FluentValidation;
using ProdZest.Api.Domain.Entities;

namespace ProdZest.Api.CrossCutting.DependencyInjection.Validation;
public class ProductValidator : AbstractValidator<Product>
{
    public ProductValidator()
    {
        RuleFor(c => c.Description)
        .MaximumLength(100).WithMessage("O campo descrição pode ter no máximo 100 caracteres")
        .MinimumLength(50).WithMessage("O campo descrição deve ter no mínimo 50 caracteres")
        .NotEmpty().WithMessage("O campo descrição não pode ser vazio");

        RuleFor(x => x.UnitPrice).GreaterThan(0).LessThanOrEqualTo(9999.99m);

        RuleFor(x => x.UnitPrice)
            .Must(v => decimal.Round(v, 2) == v)
            .WithMessage("O valor deve ter no máximo 2 casas decimais.");
    }
}
