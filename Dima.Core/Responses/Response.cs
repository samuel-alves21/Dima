using System.Text.Json.Serialization;

namespace Dima.Core.Responses;

public class Response<TData>(TData? data, int code = 200, string? message = null)
{
    private readonly int _code = code;
    public string? Message { get; set; } = message;
    public TData? Data { get; set; } = data;

    [JsonIgnore]
    public bool IsSuccess => _code >= 200 && _code < 300;
}