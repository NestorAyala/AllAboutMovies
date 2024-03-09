using Backend.Responses;
using MediatR;

namespace Application.Services.GetMovieById;

public record GetMovieByIdServerRequest(int Id) : IRequest<GetMovieByIdResponse>;