using Backend.Exceptions;
using Backend.Responses;
using Database;
using EntityDefinitions.Entities;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Services.GetMovieById;

public class GetMovieByIdService : IRequestHandler<GetMovieByIdServerRequest, GetMovieByIdResponse>
{
    private readonly MoviesDbContext _context;
    
    public GetMovieByIdService(MoviesDbContext  moviesDbContext)
    {
        _context = moviesDbContext;
    }
    
    public async Task<GetMovieByIdResponse> Handle(GetMovieByIdServerRequest serverRequest, CancellationToken cancellationToken)
    {
        var output = await _context.Movies.FirstOrDefaultAsync(item => item.Id == serverRequest.Id, cancellationToken);

        if (output == null)
        {
            throw new NotFoundException($"{nameof(Movie)} with {nameof(Movie.Id)}: {serverRequest.Id} was not found");
        }
        
        return output.Adapt<GetMovieByIdResponse>();
    }
}