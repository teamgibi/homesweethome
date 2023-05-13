using System;
using FullSerializer;

public static class StringSerializationAPI {
    private static readonly fsSerializer Serializer = new fsSerializer();

    public static string Serialize(Type type, object value) {
        fsData data;
        Serializer.TrySerialize(type, value, out data).AssertSuccessWithoutWarnings();
        return fsJsonPrinter.CompressedJson(data);
    }

    public static object Deserialize(Type type, string serializedState) {
        fsData data = fsJsonParser.Parse(serializedState);
        object deserialized = null;
        Serializer.TryDeserialize(data, type, ref deserialized).AssertSuccessWithoutWarnings();
        return deserialized;
    }
}