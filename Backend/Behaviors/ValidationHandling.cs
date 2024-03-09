using Backend.ErrorHandling;
using Backend.Exceptions;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Application.Behaviors;

public class ValidationHandling<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public ValidationHandling(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> responseDelegate,
        CancellationToken cancellationToken)
    {
        var context = new ValidationContext<TRequest>(request);

        var results = await Task.WhenAll(_validators.Select(validatedRules => validatedRules.ValidateAsync(context, cancellationToken)));

        var errors = results
                            .Where(validations => validations.IsValid == false)
                            .SelectMany(x => x.Errors)
                            .Select(x => new ValidationErrorHandling
                            {
                                Property = x.PropertyName,
                                ErrorMessage = x.ErrorMessage
                            }).ToList();

        if (errors.Any())
        {
            throw new CustomValidationException(errors);
        }

        var response = await responseDelegate();
        return response;
    }
}