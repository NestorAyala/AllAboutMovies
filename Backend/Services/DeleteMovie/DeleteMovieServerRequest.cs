using MediatR;

namespace Application.Services.DeleteMovie;

public record DeleteMovieServerRequest(int Id) : IRequest<Unit>;