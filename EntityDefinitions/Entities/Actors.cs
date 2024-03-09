namespace EntityDefinitions.Entities;

public class Actors : BaseEntity
{
    public string? ActorName { get; set; }
    public DateTime? ActorDOB { get; set; }
    public string? ActorCareerDescription { get; set; }
}