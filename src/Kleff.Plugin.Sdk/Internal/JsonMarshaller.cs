using System.Text.Json;
using System.Text.Json.Serialization;
using Grpc.Core;

namespace Kleff.Plugin.Sdk.Internal;

internal static class JsonMarshaller
{
    // Matches Go's encoding/json behaviour: omit null fields, keep zero-value numbers.
    private static readonly JsonSerializerOptions Options = new()
    {
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
    };

    public static Marshaller<T> For<T>() => Marshallers.Create(
        serializer: value => JsonSerializer.SerializeToUtf8Bytes(value, Options),
        deserializer: data => JsonSerializer.Deserialize<T>(data, Options)!
    );
}
