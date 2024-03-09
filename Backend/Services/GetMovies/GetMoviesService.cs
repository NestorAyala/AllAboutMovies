using Backend.Responses;
using Database;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Services.GetMovies;

public class GetMoviesService : IRequestHandler<GetMoviesServerRequest, GetMoviesResponse>
{
    private readonly MoviesDbContext _context;
    
    public GetMoviesService(MoviesDbContext  moviesDbContext)
    {
        _context = moviesDbContext;
    }
    
    public async Task<GetMoviesResponse> Handle(GetMoviesServerRequest serverRequest, CancellationToken cancellationToken)
    {
        var output = await _context.Movies.ToListAsync(cancellationToken);

        return output.Adapt<GetMoviesResponse>();
    }
}