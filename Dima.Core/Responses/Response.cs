using System.Text.Json.Serialization;

namespace Dima.Core.Responses;

public class Response<TData>
{
    private readonly int _code;
    public Response(TData? data, int code = 200, string? message = null)
    {
        _code = code;
        Message = message;
        Data = data;
    }

    [JsonConstructor]
    public Response() =>  _code = 200;
    
    public string? Message { get; set; } 
    public TData? Data { get; set; }

    [JsonIgnore]
    public bool IsSuccess => _code >= 200 && _code < 300;
}