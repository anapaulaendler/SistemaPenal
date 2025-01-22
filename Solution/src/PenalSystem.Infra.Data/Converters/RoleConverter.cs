using System.Text.Json;
using System.Text.Json.Serialization;
using PenalSystem.Domain.Entities;

namespace PenalSystem.Infra.Data.Converters;

public class RoleConverter : JsonConverter<Role>
{
    public override Role Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        return Enum.Parse<Role>(reader.GetString()!, true);
    }

    public override void Write(Utf8JsonWriter writer, Role value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString());
    }
}
