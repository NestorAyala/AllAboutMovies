namespace Backend.Requests;

public record CreateMovieRequest( string MovieTitle,
                                  string MoviePlot,
                                  string MovieGenre,
                                  string MovieActors,
                                  string MovieRatings,
                                  DateTime MovieReleaseDate);
