using System.Text.Json.Serialization;

namespace Domain.Models
{
	public class Order
	{
		[JsonPropertyName("avg_price")]
		public int AvgPrice { get; set; }
		public int Cost { get; set; }

		[JsonPropertyName("created_at")]
		public int CreatedAt { get; set; }
		public IEnumerable<Execution> Executions { get; set; } = Enumerable.Empty<Execution>();
		[JsonPropertyName("external_id")]
		public string ExternalId { get; set; } = null!;
		public string Fee { get; set; } = null!;
		[JsonPropertyName("filled_qty")]
		public string FilledQty { get; set; } = null!;
		public string Id { get; set; } = null!;
		public string Instrument { get; set; } = null!;
		[JsonPropertyName("limit_price")]
		public int LimitPrice { get; set; }
		public string Qty { get; set; }
		public string Side { get; set; } = null!;
		public string Status { get; set; } = null!;
		[JsonPropertyName("stop_price")]
		public int StopPrice { get; set; }
		[JsonPropertyName("trigger_order_id")]
		public string TriggerOrderId { get; set; } = null!;
		public string Type { get; set; } = null!;
		[JsonPropertyName("updated_at")]
		public int UpdatedAt { get; set; }

		public Order(int avgPrice, int cost, int createdAt, IEnumerable<Execution> executions, string externalId, string fee, string filledQty, string id, string instrument, int limitPrice, string qty, string side, string status, int stopPrice, string triggerOrderId, string type, int updatedAt)
		{
			AvgPrice = avgPrice;
			Cost = cost;
			CreatedAt = createdAt;
			Executions = executions;
			ExternalId = externalId;
			Fee = fee;
			FilledQty = filledQty;
			Id = id;
			Instrument = instrument;
			LimitPrice = limitPrice;
			Qty = qty;
			Side = side;
			Status = status;
			StopPrice = stopPrice;
			TriggerOrderId = triggerOrderId;
			Type = type;
			UpdatedAt = updatedAt;
		}
	}
}
