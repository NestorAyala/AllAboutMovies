using Backend.Exceptions;
using Database;
using EntityDefinitions.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Services.DeleteMovie;

public class DeleteMovieService : IRequestHandler<DeleteMovieServerRequest, Unit>
{
    private MoviesDbContext _context;

    public DeleteMovieService(MoviesDbContext moviesDbContext)
    {
        _context = moviesDbContext;
    }

    public async Task<Unit> Handle(DeleteMovieServerRequest serverRequest, CancellationToken cancellationToken)
    {
        var movieToDelete = await _context.Movies.FirstOrDefaultAsync(movie => movie.Id == serverRequest.Id, cancellationToken);
        
        if (movieToDelete == null)
        {
            throw new NotFoundException($"{nameof(Movie)} with {nameof(Movie.Id)}: {serverRequest.Id} was not found");
        }
        
        _context.Movies.Remove(movieToDelete);
        await _context.SaveChangesAsync(cancellationToken);
        
        return Unit.Value;
    }
}