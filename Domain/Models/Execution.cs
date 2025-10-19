using System.Text.Json.Serialization;

namespace Domain.Models
{
	public class Execution
	{
		[JsonPropertyName("executed_at")]
		public int ExecutedAt { get; private set; }
		[JsonPropertyName("fee_rate")]
		public string FeeRate { get; private set; } = null!;
		public string Id { get; private set; } = null!;
		public string Instrument { get; private set; } = null!;
		public int Price { get; private set; }
		public string Qty { get; private set; } = null!;
		public string Side { get; private set; } = null!;
		public string Liquidity { get; private set; } = null!;

		public Execution(int executedAt, string feeRate, string id, string instrument, int price, string qty, string side, string liquidity)
		{
			ExecutedAt = executedAt;
			FeeRate = feeRate;
			Id = id;
			Instrument = instrument;
			Price = price;
			Qty = qty;
			Side = side;
			Liquidity = liquidity;
		}
	}
}
