using Microsoft.EntityFrameworkCore;
using MoviesApi.Data;
using MoviesApi.Mappers;
using MoviesApi.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer"))
);

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// Adding the repositories
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();

// Adding the mappers
builder.Services.AddAutoMapper(typeof(MovieMapper));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
