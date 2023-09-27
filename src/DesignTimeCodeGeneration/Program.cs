using System.Text.Json;

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
