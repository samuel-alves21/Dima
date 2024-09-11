var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/products/", () => "Hello World!");
app.MapGet("/products/{id}", () => "Hello World!");
app.MapGet("/products/{id}/categories", () => "Hello World!");
app.MapGet("/products/{id}/categories/{cid}/sub-categories", () => "Hello World!");


app.MapPost("/", () => "Hello World!");
app.MapPut("/", () => "Hello World!");
app.MapDelete("/", () => "Hello World!");

app.Run();
