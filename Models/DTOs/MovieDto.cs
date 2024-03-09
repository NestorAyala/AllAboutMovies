namespace Backend.DTOs;

public record MovieDto(int Id,
                       string? MovieTitle, 
                       string? MoviePlot, 
                       string? MovieGenre, 
                       string? MovieActors, 
                       string? MovieRatings, 
                       DateTime? MovieReleaseDate);
