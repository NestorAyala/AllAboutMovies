namespace EntityDefinitions.Entities;

// Relationship entity that links an actor to a movie and vice versa
public class Movies_Actors : BaseEntity
{
    public int MovieId { get; set; }
    public int ActorId { get; set; }
}