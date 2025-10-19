using System.Text.Json.Serialization;

namespace Domain.Records.Responses.Auth
{
	public record AuthResponse(
		[property: JsonPropertyName("access_token")] string AccessToken,
		[property: JsonPropertyName("expiration")] long Expiration
	);
}
