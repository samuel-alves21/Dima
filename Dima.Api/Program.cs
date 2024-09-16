var builder = WebApplication.CreateBuilder(args);


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen((x) =>
{
    x.CustomSchemaIds((n) => n.FullName);
});

builder.Services.AddTransient<Handler>();

var app = builder.Build();

app.UseSwaggerUI();
app.UseSwagger();

app.MapPost("/v2/transactions", (Request request, Handler handler) =>
{
    return handler.Handle(request);
})  
    .WithName("Transactions: Create")
    .WithSummary("Cria uma nova transação")
    .Produces<Response>();

app.Run();
public class Request
{
    public string Title { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public int Type { get; set; } 
    public decimal Amount { get; set; }
    public long CategoryId { get; set; }
    public string UserId { get; set; } = string.Empty;
}

public class Response
{
    public string Title { get; set; }
    public int Id { get; set; }
}

public class Handler
{
    public Response Handle(Request request)
    {
        return new Response { Title = request.Title, Id = 4 };
    }
};