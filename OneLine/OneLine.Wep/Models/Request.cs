using static OneLine.Wep.Utility.SD;

namespace OneLine.Wep.Models
{
    public class Request
    {
        public ApiType ApiType { get; set; } = ApiType.GET;
        public required string Url { get; set; }
        public object? Data { get; set; } = null;
        public string AccessToken { get; set; } = string.Empty;
    }
}
