using System.Text.Json.Serialization;

public class Property
{
    [JsonPropertyName("type")]
    public required string Type { get; set; }

    [JsonPropertyName("name")]
    public required string Name { get; set; }
}