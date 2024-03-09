using Backend.DTOs;

namespace Backend.Responses;

public record GetMoviesResponse(List<MovieDto> MoviesDto);