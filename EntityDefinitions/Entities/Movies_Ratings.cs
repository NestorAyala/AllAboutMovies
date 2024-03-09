namespace EntityDefinitions.Entities;

// Relationship entity that links a rating to a movie and vice versa
public class Movies_Ratings: BaseEntity
{
    public int MovieId { get; set; }
    public int RatingId { get; set; }
}