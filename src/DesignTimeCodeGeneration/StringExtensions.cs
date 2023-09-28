// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
using static System.Linq.Enumerable;


public static class StringExtensions
{
    public static string Indent(this string value, int indent, int spaces = 4)
    {
        try
        {
            string[] values = value.Split(Environment.NewLine);

            var result = string.Join(Environment.NewLine, values.Select(v => string.IsNullOrEmpty(v) ? v : $"{string.Join(string.Empty, Range(1, spaces * indent).Select(i => ' '))}{v}"));

            return result;
        }
        catch (Exception e)
        {
            throw;
        }
    }

    public static string ToCamelCase(this string input)
    {
        if (string.IsNullOrEmpty(input))
        {
            return input;
        }

        var words = input.Split(new[] { ' ', '_' }, StringSplitOptions.RemoveEmptyEntries);
        var result = words[0].ToLower();
        for (int i = 1; i < words.Length; i++)
        {
            result += words[i].Substring(0, 1).ToUpper() + words[i].Substring(1).ToLower();
        }

        return result;
    }

    public static string ToPascalCase(this string input)
    {
        if (string.IsNullOrEmpty(input))
        {
            return input;
        }

        var words = input.Split(new[] { ' ', '_' }, StringSplitOptions.RemoveEmptyEntries);
        var result = string.Empty;
        foreach (var word in words)
        {
            result += word.Substring(0, 1).ToUpper() + word.Substring(1).ToLower();
        }

        return result;
    }
}