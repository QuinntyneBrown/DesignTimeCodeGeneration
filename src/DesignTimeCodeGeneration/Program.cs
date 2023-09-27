using System.Text.Json;
using System.Text.Json.Serialization;

var data = File.ReadAllText($@"..\..\..\..\..\data\definitions.json");

var definitions = JsonSerializer.Deserialize<SimpleTypesDefinitionsDocument>(data)!;

foreach(var item in definitions.SimpleTypes)
{
    Generate(item);
}

void Generate(SimpleType model)
{    
    var result = $$"""
        public record struct {{model.Name}}({{string.Join(",",model.Properties.Select(x => $"{x.Type} {x.Name}"))}});
        """;

    File.WriteAllText($@"..\..\..\..\Target\{model.Name}.g.cs", result);
}


public class SimpleTypesDefinitionsDocument
{
    [JsonPropertyName("simpleTypes")]
    public required List<SimpleType> SimpleTypes { get; set; }
}

public class SimpleType
{
    [JsonPropertyName("name")]
    public required string Name { get; set; }

    [JsonPropertyName("properties")]
    public required List<Property> Properties { get; set; }
}

public class Property
{
    [JsonPropertyName("type")]
    public required string Type { get; set; }

    [JsonPropertyName("name")]
    public required string Name { get; set; }
}