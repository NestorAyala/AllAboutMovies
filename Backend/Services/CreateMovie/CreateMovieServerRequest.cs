using MediatR;

namespace Application.Services.CreateMovie;

public record CreateMovieServerRequest(string MovieTitle
                                , string MoviePlot
                                , string MovieGenre
                                , string MovieActors
                                , string MovieRatings
                                , DateTime MovieReleaseDate) : IRequest<int>;