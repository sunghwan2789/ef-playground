using System.Text.Json;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infrastructure;

public static class JsonValueConversionExtensions
{
    private static readonly JsonSerializerOptions Options = new();

    public static PropertiesConfigurationBuilder<T> HaveJsonConversion<T>(this PropertiesConfigurationBuilder<T> builder)
    {
        builder.HaveConversion<JsonValueConverter<T>, JsonValueComparer<T>>();
        return builder;
    }

    private class JsonValueConverter<T> : ValueConverter<T, string>
    {
        public JsonValueConverter() : base(
            v => JsonSerializer.Serialize(v, Options),
            v => JsonSerializer.Deserialize<T>(v, Options)!) { }
    }

    private class JsonValueComparer<T> : ValueComparer<T>
    {
        public JsonValueComparer() : base(
            (l, r) => JsonSerializer.Serialize(l, Options) == JsonSerializer.Serialize(r, Options),
            v => v == null ? 0 : JsonSerializer.Serialize(v, Options).GetHashCode(),
            v => JsonSerializer.Deserialize<T>(JsonSerializer.Serialize(v, Options), Options)!) { }
    }
}
