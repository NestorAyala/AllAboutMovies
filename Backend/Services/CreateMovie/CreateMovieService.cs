using Database;
using EntityDefinitions.Entities;
using MediatR;

namespace Application.Services.CreateMovie;

public class CreateMovieService : IRequestHandler<CreateMovieServerRequest, int>
{
    private readonly MoviesDbContext _context;

    public CreateMovieService(MoviesDbContext moviesDbContext)
    {
        _context = moviesDbContext;
    }

    public async Task<int> Handle(CreateMovieServerRequest serverRequest, CancellationToken cancellationToken)
    {
        var movie = new Movie();
        movie.MovieTitle = serverRequest.MovieTitle;
        movie.MoviePlot = serverRequest.MoviePlot;
        movie.MovieGenre = serverRequest.MovieGenre;
        movie.MovieActors = serverRequest.MovieActors;
        movie.MovieRatings = serverRequest.MovieRatings;
        movie.MovieReleaseDate = serverRequest.MovieReleaseDate;
        
        await _context.Movies.AddAsync(movie, cancellationToken);
        await _context.SaveChangesAsync();
        
        return movie.Id;
    }
}