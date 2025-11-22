using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace ProdZest.Api.CrossCutting.DependencyInjection.Validation.Base;
public static class ValidatorsDependencyInjection
{
    public static IServiceCollection AddValidators(this IServiceCollection services)
    {
        services.AddValidatorsFromAssemblyContaining(typeof(ProductValidator));
        return services;
    }
}
