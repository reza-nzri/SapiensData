using System.Text.Json;
using System.Text.Json.Serialization;

//public class SingleOrArrayConverter<T> : JsonConverter<List<T>>
//{
//	public override List<T> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
//	{
//		if (reader.TokenType == JsonTokenType.StartArray)
//		{
//			return JsonSerializer.Deserialize<List<T>>(ref reader, options);
//		}
//		else
//		{
//			// If it's not an array, treat it as a single element list
//			T singleValue = JsonSerializer.Deserialize<T>(ref reader, options);
//			return new List<T> { singleValue };
//		}
//	}

//	public override void Write(Utf8JsonWriter writer, List<T> value, JsonSerializerOptions options)
//	{
//		JsonSerializer.Serialize(writer, value, options);
//	}
//}

public class SingleOrArrayConverter<T> : JsonConverter<List<T>>
{
	public override List<T> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
	{
		if (reader.TokenType == JsonTokenType.StartArray)
		{
			// Deserialize as a list of T if it's an array
			return JsonSerializer.Deserialize<List<T>>(ref reader, options) ?? []; // Handle null by returning an empty list
		}
		else
		{
			// If it's not an array, treat it as a single element and return it as a list
			T? singleValue = JsonSerializer.Deserialize<T>(ref reader, options); // If T is a nullable type (e.g., string?)

			return singleValue != null ? [singleValue] : []; // Return empty list if singleValue is null
		}
	}

	public override void Write(Utf8JsonWriter writer, List<T> value, JsonSerializerOptions options)
	{
		// Ensure value is not null before serializing
		if (value == null)
		{
			writer.WriteStartArray(); // Write an empty array if value is null
			writer.WriteEndArray();
		}
		else
		{
			JsonSerializer.Serialize(writer, value, options); // Serialize as usual if value is not null
		}
	}
}


namespace SapiensDataAPI.Dtos
{
	public class JwtPayload
	{
		[JsonPropertyName("sub")]
		public string Sub { get; set; } = string.Empty;

		[JsonPropertyName("jti")]
		public string Jti { get; set; } = string.Empty;

		[JsonPropertyName("role")]
		[JsonConverter(typeof(SingleOrArrayConverter<string>))]
		public List<string> Role { get; set; } = [];

		[JsonPropertyName("exp")]
		public long Exp { get; set; } = 0;

		[JsonPropertyName("iss")]
		public string Iss { get; set; } = string.Empty;

		[JsonPropertyName("aud")]
		public string Aud { get; set; } = string.Empty;
	}
}