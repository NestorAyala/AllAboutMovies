using EntityDefinitions.Entities;
using FluentValidation;

namespace Application.Services.UpdateMovie;

public class UpdateMovieServiceValidations : AbstractValidator<UpdateMovieServerRequest>
{
    public UpdateMovieServiceValidations()
    {
        RuleFor(input => input.Id)
            .NotEmpty()
            .WithMessage($"{nameof(Movie.Id)} cannot be empty.");
        
        RuleFor(input => input.MovieTitle)
            .NotEmpty()
            .WithMessage($"{nameof(Movie.MovieTitle)} is required.")
            .MaximumLength(25)
            .WithMessage($"The {nameof(Movie.MovieTitle)} must be less than 25 characters.");
        
        RuleFor(input => input.MoviePlot)
            .MaximumLength(250)
            .WithMessage($"The {nameof(Movie.MoviePlot)} must be less than 250 characters.");
        
        RuleFor(input => input.MovieGenre)
            .MaximumLength(25)
            .WithMessage($"The {nameof(Movie.MovieGenre)} must be less than 25 characters.");
        
        RuleFor(input => input.MovieActors)
            .MaximumLength(250)
            .WithMessage($"The {nameof(Movie.MovieActors)} must be less than 250 characters.");
        
        RuleFor(input => input.MovieRatings)
            .MaximumLength(30)
            .WithMessage($"The {nameof(Movie.MovieRatings)} must be less than 30 characters.");

        RuleFor(input => input.MovieReleaseDate)
            .NotEmpty()
            .WithMessage($"{nameof(Movie.MovieReleaseDate)} is required.")
            .GreaterThan(new DateTime(1888, 1, 1))
            .WithMessage($"No movie was created before 1888.");
    }
}