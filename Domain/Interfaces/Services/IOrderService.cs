
using Domain.Models;
using Domain.Records.Requests;

namespace Domain.Interfaces.Services
{
	public interface IOrderService
	{
		Task<IEnumerable<Order>> GetAsync(string accountId, string symbol, OrderQueryParams queryParams);
	}
}
