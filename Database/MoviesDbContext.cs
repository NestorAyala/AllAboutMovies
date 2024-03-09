﻿using EntityDefinitions.Entities;
using Microsoft.EntityFrameworkCore;

namespace Database;

public class MoviesDbContext : DbContext
{
    public MoviesDbContext(DbContextOptions<MoviesDbContext> options) : base(options)
    {
    }
    
    public DbSet<Movie> Movies { get; set; }
}