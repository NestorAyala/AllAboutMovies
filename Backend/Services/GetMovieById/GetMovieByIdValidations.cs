using EntityDefinitions.Entities;
using FluentValidation;

namespace Application.Services.GetMovieById;

public class GetMovieByIdValidations : AbstractValidator<GetMovieByIdServerRequest>
{
    public GetMovieByIdValidations()
    {
        RuleFor(input => input.Id)
            .NotEmpty()
            .WithMessage($"{nameof(Movie.Id)} cannot be empty.");
    }
}