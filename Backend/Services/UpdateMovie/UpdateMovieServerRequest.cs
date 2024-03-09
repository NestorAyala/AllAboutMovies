using MediatR;

namespace Application.Services.UpdateMovie;

public record UpdateMovieServerRequest(int Id
                                , string MovieTitle
                                , string MoviePlot
                                , string MovieGenre
                                , string MovieActors
                                , string MovieRatings
                                , DateTime MovieReleaseDate) : IRequest<Unit>;