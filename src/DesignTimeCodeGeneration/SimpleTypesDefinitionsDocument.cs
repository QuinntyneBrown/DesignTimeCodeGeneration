using System.Text.Json.Serialization;

public class SimpleTypesDefinitionsDocument
{
    [JsonPropertyName("simpleTypes")]
    public required List<SimpleType> SimpleTypes { get; set; }
}
