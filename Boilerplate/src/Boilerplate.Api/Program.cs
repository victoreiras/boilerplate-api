using System.Reflection;
using Boilerplate.Api.Configurations;
using Boilerplate.Api.Middlewares;
using Boilerplate.Infrastructure.Persistence.Context;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen(options =>
{
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    options.IncludeXmlComments(xmlPath);
});

builder.Services.AddControllers();

builder.Services.AddServices();
builder.Services.AddAppDbContext();
builder.Services.AddApiVersion();
builder.Services.AddCache();
builder.Services.AddRepositories();

builder.Services.AddHealthChecks()
    .AddDbContextCheck<AppDbContext>("sqlite", tags: new[] { "db", "ready" });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    //app.MapScalarApiReference(options =>
    //    options
    //        .WithTitle("Minha API personalizada")
    //);

    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapHealthChecks("/health");

app.Run();
