using Boilerplate.Api.Middlewares;
using Boilerplate.Application.Usecases.CreateProject;
using Boilerplate.Domain.Repositories;
using Boilerplate.Infrastructure.Persistence.Context;
using Boilerplate.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddScoped<AppDbContext>();
builder.Services.AddScoped<ICreateProject, CreateProject>();
builder.Services.AddScoped<IProjectRepository, ProjectRepository>();

builder.Services.AddDbContext<AppDbContext>(options => 
    options.UseSqlite("DataSource=ProjetoDB.db"));

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

app.UseMiddleware<ExceptionMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
