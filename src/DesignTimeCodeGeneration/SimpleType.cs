using System.Text.Json.Serialization;

public class SimpleType
{
    [JsonPropertyName("name")]
    public required string Name { get; set; }

    [JsonPropertyName("sourceType")]
    public required string SourceType { get; set; }

    [JsonPropertyName("validations")]
    public List<Validation> Validations { get; set; }
}


public class Validation
{
    [JsonPropertyName("maxValue")]
    public int MaxValue { get; set; }

    [JsonPropertyName("errorMessage")]
    public string? ErrorMessasge { get; set; }
}