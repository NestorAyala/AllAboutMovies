namespace Backend.Requests;

public record UpdateMovieRequest(int Id,
                                 string MovieTitle,
                                 string MoviePlot,
                                 string MovieGenre,
                                 string MovieActors,
                                 string MovieRatings,
                                 DateTime MovieReleaseDate);