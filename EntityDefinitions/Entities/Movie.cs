namespace EntityDefinitions.Entities;

public class Movie : BaseEntity
{
    public string MovieTitle { get; set; }
    public string MoviePlot { get; set; }
    public string MovieGenre { get; set; }
    public string MovieActors { get; set; }
    public string MovieRatings { get; set; }
    public DateTime MovieReleaseDate { get; set; }
}