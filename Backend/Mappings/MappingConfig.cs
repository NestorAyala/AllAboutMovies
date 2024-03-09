using Backend.DTOs;
using Backend.Responses;
using EntityDefinitions.Entities;
using Mapster;

namespace Application.Mappings;

public class MappingConfig
{
    public static void Configure()
    {
        TypeAdapterConfig<List<Movie>, GetMoviesResponse>.NewConfig()
            .Map(destination => destination.MoviesDto, src => src);

        TypeAdapterConfig<Movie, GetMovieByIdResponse>.NewConfig()
            .Map(destination => destination.MovieDto, src => src);
    }
}