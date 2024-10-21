namespace Dima.Core;

public static class Configuration
{
    public const int DefaultPageSize  = 25;
    public const int DefaultPageNumber  = 1;

    public static string ConnectionString { get; set; } = "";
    public static string FrontendUrl { get; set; } = "";
    public static string BackendUrl { get; set; } = "";
}