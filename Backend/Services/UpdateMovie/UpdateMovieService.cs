using Backend.Exceptions;
using Database;
using EntityDefinitions.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Services.UpdateMovie;

public class UpdateMovieService : IRequestHandler<UpdateMovieServerRequest, Unit>
{
    private MoviesDbContext _context;

    public UpdateMovieService(MoviesDbContext moviesDbContext)
    {
        _context = moviesDbContext;
    }

    public async Task<Unit> Handle(UpdateMovieServerRequest serverRequest, CancellationToken cancellationToken)
    {
        var movieToUpdate = await _context.Movies.FirstOrDefaultAsync(movie => movie.Id == serverRequest.Id, cancellationToken);
        
        if (movieToUpdate == null)
        {
            throw new NotFoundException($"{nameof(Movie)} with {nameof(Movie.Id)}: {serverRequest.Id} was not found");
        }
        
        movieToUpdate.MovieTitle = serverRequest.MovieTitle;
        movieToUpdate.MoviePlot = serverRequest.MoviePlot;
        movieToUpdate.MovieGenre = serverRequest.MovieGenre;
        movieToUpdate.MovieActors = serverRequest.MovieActors;
        movieToUpdate.MovieRatings = serverRequest.MovieRatings;
        movieToUpdate.MovieReleaseDate = serverRequest.MovieReleaseDate;

        _context.Movies.Update(movieToUpdate);
        await _context.SaveChangesAsync(cancellationToken);
        
        return Unit.Value;
    }
}