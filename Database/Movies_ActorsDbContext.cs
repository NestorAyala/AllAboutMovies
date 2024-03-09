using EntityDefinitions.Entities;
using Microsoft.EntityFrameworkCore;

namespace Database;

public class Movies_ActorsDbContext : DbContext
{
    public Movies_ActorsDbContext(DbContextOptions<Movies_ActorsDbContext> options) : base(options)
    {
    }
    
    public DbSet<Movies_Actors> Movies_Actors { get; set; }
}