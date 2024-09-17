public class ApiErrorResponse
{
    public string Type { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public int Status { get; set; }
    public Dictionary<string, string[]> Errors { get; set; } = [];
}
