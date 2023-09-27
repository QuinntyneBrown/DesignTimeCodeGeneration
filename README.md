# Design-Time Code Generation
Introductory Design-Time Code Generation project using C#. 

## Give a Star! :star:

If you like or are using this project to learn or start your solution, please give it a star. Thanks!

## Table of Contents
- [What is Design-Time Code Generation](#whatisit)

  

## What is Design-Time Code Generation

 <img src="images/code-generation-1.jpg" />


 ### Template

 ```csharp
    var result = $$"""
        public record struct {{model.Name}}({{string.Join(",",model.Properties.Select(x => $"{x.Type} {x.Name}"))}});
        """;
 ```

 ### Data / Model / User Input
 ```data
{
    "simpleTypes": [
      {
        "name": "HelloWorld",
        "namespace": "Target",
        "properties": [
          {
            "name": "Greeting",
            "type": "string"
          }
        ]
      }
    ]
}
 ```

 ### Generation Strategy
 ```csharp
void Generate(SimpleType model)
{    
    var result = $$"""
        public record struct {{model.Name}}({{string.Join(",",model.Properties.Select(x => $"{x.Type} {x.Name}"))}});
        """;

    File.WriteAllText($@"..\..\..\..\Target\{model.Name}.g.cs", result);
}
 ```

### Additional Resources
