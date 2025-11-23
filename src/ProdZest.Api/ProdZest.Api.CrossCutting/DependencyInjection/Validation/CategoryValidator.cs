using FluentValidation;
using ProdZest.Api.Domain.Entities;

namespace ProdZest.Api.CrossCutting.DependencyInjection.Validation;
public class CategoryValidator : AbstractValidator<Category>
{
    public CategoryValidator()
    {
        RuleFor(c => c.Description)
        .MaximumLength(100).WithMessage("O campo descrição pode ter no máximo 100 caracteres")
        .MinimumLength(50).WithMessage("O campo descrição deve ter no mínimo 50 caracteres")
        .NotEmpty().WithMessage("O campo descrição não pode ser vazio");
    }
}