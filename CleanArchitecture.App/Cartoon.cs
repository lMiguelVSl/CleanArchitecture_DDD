using System.Text.Json.Serialization;

namespace CleanArchitecture.App;

public class Cartoon
{
    [JsonPropertyName("title")]
    public string Title { get; set; }

    [JsonPropertyName("year")]
    public int Year { get; set; }

    [JsonPropertyName("creator")]
    public List<string> Creator { get; set; }

    [JsonPropertyName("rating")]
    public string Rating { get; set; }

    [JsonPropertyName("genre")]
    public List<string> Genre { get; set; }

    [JsonPropertyName("runtime_in_minutes")]
    public int RuntimeInMinutes { get; set; }

    [JsonPropertyName("episodes")]
    public int Episodes { get; set; }

    [JsonPropertyName("image")]
    public string Image { get; set; }

    [JsonPropertyName("id")]
    public int Id { get; set; }
}