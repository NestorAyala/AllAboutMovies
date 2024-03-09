using EntityDefinitions.Entities;
using Microsoft.EntityFrameworkCore;

namespace Database;

public class Movies_RatingsDbContext : DbContext
{
    public Movies_RatingsDbContext(DbContextOptions<Movies_RatingsDbContext> options) : base(options)
    {
    }
    
    public DbSet<Movies_Ratings> Movies_Ratings { get; set; }
}