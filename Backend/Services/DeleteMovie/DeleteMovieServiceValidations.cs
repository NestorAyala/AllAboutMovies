using EntityDefinitions.Entities;
using FluentValidation;

namespace Application.Services.DeleteMovie;

public class DeleteMovieServiceValidations : AbstractValidator<DeleteMovieServerRequest>
{
    public DeleteMovieServiceValidations()
    {
        RuleFor(input => input.Id)
            .NotEmpty()
            .WithMessage($"{nameof(Movie.Id)} cannot be empty.");
    }
}