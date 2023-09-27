using System.Text.Json.Serialization;

public class SimpleType
{
    [JsonPropertyName("name")]
    public required string Name { get; set; }

    [JsonPropertyName("properties")]
    public required List<Property> Properties { get; set; }
}
