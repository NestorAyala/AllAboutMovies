using EntityDefinitions.Entities;
using Microsoft.EntityFrameworkCore;

namespace Database;

public class RatingsDbContext : DbContext
{
    public RatingsDbContext(DbContextOptions<RatingsDbContext> options) : base(options)
    {
    }
    
    public DbSet<MovieRatings> Ratings { get; set; }
}