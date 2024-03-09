using Backend.Responses;
using MediatR;

namespace Application.Services.GetMovies;

public record GetMoviesServerRequest() : IRequest<GetMoviesResponse>;