using EntityDefinitions.Entities;
using Microsoft.EntityFrameworkCore;

namespace Database;

public class ActorsDbContext : DbContext
{
    public ActorsDbContext(DbContextOptions<ActorsDbContext> options) : base(options)
    {
    }
    
    public DbSet<Actors> Actors { get; set; }
}