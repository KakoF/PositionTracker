using Domain.Models;
using Domain.Records.Requests;

namespace Domain.Interfaces.Infrastructure
{
	public interface IBitconMarketClient
	{
		Task<IEnumerable<Account>> GetAccountsAsync();
		Task<IEnumerable<Order>> GetOrdersAsync(string accountId, string symbol, OrderQueryParams queryParams);
	}
}
