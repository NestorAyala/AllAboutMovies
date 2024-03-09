using Application.Services.CreateMovie;
using Application.Services.DeleteMovie;
using Application.Services.GetMovieById;
using Application.Services.GetMovies;
using Application.Services.UpdateMovie;
using Backend.Requests;
using MediatR;

namespace AllAboutMovies.Modules;

public static class MoviesModules
{
    // This class contains extension methods for configuring movie-related endpoints.
    public static void AddMoviesEndpoints(this IEndpointRouteBuilder app)
    {
        // Endpoint for retrieving all movies.
        app.MapGet("/api/movies", async (IMediator mediator, CancellationToken cancellationToken) =>
        {
            var movies = await mediator.Send(new GetMoviesServerRequest(), cancellationToken);
            return Results.Ok(movies);
        }).WithTags("Movies");

        // Endpoint for retrieving a specific movie by its ID.
        app.MapGet("/api/movies/{id}", async (IMediator mediator, int id, CancellationToken cancellationToken) =>
        {
            var movie = await mediator.Send(new GetMovieByIdServerRequest(id), cancellationToken);
            return Results.Ok(movie);
        }).WithTags("Movies");
        
        // Endpoint for creating a new movie.
        app.MapPost("/api/movies", async (IMediator mediator, CreateMovieRequest createMovieRequest, CancellationToken cancellationToken) =>
        {
            var request = new CreateMovieServerRequest(createMovieRequest.MovieTitle,
                                                       createMovieRequest.MoviePlot,
                                                       createMovieRequest.MovieGenre,
                                                       createMovieRequest.MovieActors,
                                                       createMovieRequest.MovieRatings,
                                                       createMovieRequest.MovieReleaseDate);
            
            var result = await mediator.Send(request, cancellationToken);
            return Results.Ok(result);
        }).WithTags("Movies");

        // Endpoint for updating an existing movie.
        app.MapPut("/api/movies/{id}", async (IMediator mediator, int id, UpdateMovieRequest updateMovieRequest, CancellationToken cancellationToken) =>
        {
            var request = new UpdateMovieServerRequest(id,
                                                       updateMovieRequest.MovieTitle, 
                                                       updateMovieRequest.MoviePlot,
                                                       updateMovieRequest.MovieGenre,
                                                       updateMovieRequest.MovieActors,
                                                       updateMovieRequest.MovieRatings,
                                                       updateMovieRequest.MovieReleaseDate);

            var result = await mediator.Send(request, cancellationToken);
            return Results.Ok(result);
        }).WithTags("Movies");

        // Endpoint for deleting a movie by its ID.
        app.MapDelete("/api/movies/{id}", async (IMediator mediator, int id, CancellationToken cancellationToken) =>
        {
            var request = new DeleteMovieServerRequest(id);

            var result = await mediator.Send(request, cancellationToken);
            return Results.Ok(result);
        }).WithTags("Movies");
    }
}