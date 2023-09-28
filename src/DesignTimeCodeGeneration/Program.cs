//https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/user-defined-conversion-operators

using System.Text.Json;

var data = File.ReadAllText($@"..\..\..\..\..\data\definitions.json");

var definitions = JsonSerializer.Deserialize<SimpleTypesDefinitionsDocument>(data)!;

foreach(var item in definitions.SimpleTypes)
{
    Generate(item);
}

void Generate(SimpleType model)
{

    string validations = string.Join(Environment.NewLine, model.Validations.Select(x =>
    {
        return $$"""
        if ({{model.Name.ToCamelCase()}} > {{x.MaxValue}})
        {
            throw new ArgumentOutOfRangeException(nameof({{model.Name.ToCamelCase()}}), "{{x.ErrorMessasge}}");
        }

        """;
    }));

    var result = $$"""
        public readonly struct {{model.Name.ToPascalCase()}}
        {
            private readonly {{model.SourceType}} {{model.Name.ToCamelCase()}};

            public {{model.Name.ToPascalCase()}}({{model.SourceType}} {{model.Name.ToCamelCase()}})
            {
                {{validations.Indent(2)}}
                this.{{model.Name.ToCamelCase()}} = {{model.Name.ToCamelCase()}};
            }

            public static implicit operator {{model.SourceType}}({{model.Name.ToPascalCase()}} value) => value.{{model.Name.ToCamelCase()}};
            public static explicit operator {{model.Name.ToPascalCase()}}({{model.SourceType}} value) => new {{model.Name.ToPascalCase()}}(value);

            public override string ToString() => $"{{{model.Name.ToCamelCase()}}}";
        }
        """;

    File.WriteAllText($@"..\..\..\..\Target\{model.Name}.g.cs", result);
}
