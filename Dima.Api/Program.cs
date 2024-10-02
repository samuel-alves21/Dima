using Dima.Api.Data;
using Dima.Api.Endpoints;
using Dima.Api.Handlers;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? "";

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(connectionString);
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen((x) =>
{
    x.CustomSchemaIds((n) => n.FullName);
});

builder.Services.AddTransient<CategoryHandler>();

var app = builder.Build();

app.UseSwaggerUI();
app.UseSwagger();

app.MapGet("/", () => new { Message = "Ok" }); 
app.MapEndpoints();

app.Run();  
