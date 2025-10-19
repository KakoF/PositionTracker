
using Domain.Interfaces.Infrastructure;
using Domain.Interfaces.Services;
using Domain.Models;
using Domain.Records.Requests;

namespace Application.Services
{
	public class OrderService : IOrderService
	{
		private readonly IBitconMarketClient _bitconMarketClient;
		public OrderService(IBitconMarketClient bitconMarketClient)
		{
			_bitconMarketClient = bitconMarketClient;
		}
		public async Task<IEnumerable<Order>> GetAsync(string accountId, string symbol, OrderQueryParams queryParams)
		{
			return await _bitconMarketClient.GetOrdersAsync(accountId, symbol, queryParams);
		}
	}
}
