using System.Text.Json;
using System.Text.Json.Serialization;

public class SingleOrArrayConverter<T> : JsonConverter<List<T>>
{
	public override List<T> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
	{
		if (reader.TokenType == JsonTokenType.StartArray)
		{
			return JsonSerializer.Deserialize<List<T>>(ref reader, options);
		}
		else
		{
			// If it's not an array, treat it as a single element list
			T singleValue = JsonSerializer.Deserialize<T>(ref reader, options);
			return new List<T> { singleValue };
		}
	}

	public override void Write(Utf8JsonWriter writer, List<T> value, JsonSerializerOptions options)
	{
		JsonSerializer.Serialize(writer, value, options);
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
		public List<string> Role { get; set; } = new List<string>();

		[JsonPropertyName("exp")]
		public long Exp { get; set; }

		[JsonPropertyName("iss")]
		public string Iss { get; set; } = string.Empty;

		[JsonPropertyName("aud")]
		public string Aud { get; set; } = string.Empty;
	}
}