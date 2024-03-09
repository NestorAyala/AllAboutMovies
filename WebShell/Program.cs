using AllAboutMovies.Handlers;
using AllAboutMovies.Modules;
using Application;
using Database;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services required for endpoint API explorer and Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure SQLite database contexts for Movies, Actors, and Ratings
builder.Services.AddDbContext<MoviesDbContext>(opt =>
{
    opt.UseSqlite(builder.Configuration.GetConnectionString(name: "DatabaseConnectionString"));
});
builder.Services.AddDbContext<ActorsDbContext>(opt =>
{
    opt.UseSqlite(builder.Configuration.GetConnectionString(name: "DatabaseConnectionString"));
});
builder.Services.AddDbContext<RatingsDbContext>(opt =>
{
    opt.UseSqlite(builder.Configuration.GetConnectionString(name: "DatabaseConnectionString"));
});

// Configure CORS policy to allow requests from a specific origin
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", policyBuilder =>
    {
        policyBuilder.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:5173");
    });
});

// Add application services and exception handling
builder.Services.AddApplication();
builder.Services.AddExceptionHandler<ExceptionHandler>();

// If the application environment is development, enable Swagger UI
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Use exception handling, CORS policy, HTTPS redirection, and add endpoints for movies
app.UseExceptionHandler(_ => { });
app.UseCors("CorsPolicy");
app.UseHttpsRedirection();
app.AddMoviesEndpoints();

app.Run();
