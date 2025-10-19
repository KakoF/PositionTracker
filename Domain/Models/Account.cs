using System.Text.Json.Serialization;

namespace Domain.Models
{
	public class Account
	{
		[JsonPropertyName("created_at")]
		public string Currency { get; private set; } = null!;
		[JsonPropertyName("currency_sign")]
		public string CurrencySign { get; private set; } = null!;
		public string Id { get; private set; } = null!;
		public string Name { get; private set; } = null!;
		public string Type { get; private set; } = null!;

		public Account(string currency, string currencySign, string id, string name, string type)
		{
			Currency = currency;
			CurrencySign = currencySign;
			Id = id;
			Name = name;
			Type = type;
		}
	}
}
