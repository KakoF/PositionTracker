using System.Text.Json.Serialization;

namespace Domain.Records.Requests
{
	public record OrderQueryParams([property: JsonPropertyName("created_at_from")] DateTime? CreatedAtFrom, [property: JsonPropertyName("created_at_to")] DateTime? CreatedAtTo);

}
