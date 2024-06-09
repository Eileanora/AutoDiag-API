using System.Text.Json;
using System.Text.Json.Serialization;

namespace AutoDiag.BL.Utils.OrderedPropertiesJson;

public class MicrosoftOrderedPropertiesConverter<T> : JsonConverter<T>
{
    public override bool CanConvert(Type typeToConvert)
    {
        return typeof(T).IsAssignableFrom(typeToConvert);
    }

    public override T? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions? options)
    {
        return JsonSerializer.Deserialize<T>(ref reader, options);
    }

    public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
    {
        writer.WriteStartObject();

        var properties = typeof(T).GetProperties();
        var idProperty = properties.FirstOrDefault(p => p.Name == "Id");
        var baseProperties = properties.Where(p => p.DeclaringType == typeof(T).BaseType && p.Name != "Id");
        var derivedProperties = properties.Where(p => p.DeclaringType == typeof(T) && p.Name != "Id");

        if (idProperty != null)
        {
            var idValue = idProperty.GetValue(value);
            writer.WritePropertyName(idProperty.Name);
            JsonSerializer.Serialize(writer, idValue, options);
        }

        foreach (var property in baseProperties.Concat(derivedProperties))
        {
            var propertyValue = property.GetValue(value);

            writer.WritePropertyName(property.Name);

            JsonSerializer.Serialize(writer, propertyValue, options);
        }

        writer.WriteEndObject();
    }
}