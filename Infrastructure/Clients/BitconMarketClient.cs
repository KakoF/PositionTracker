using Domain.Exceptions;
using Domain.Extensions;
using Domain.Interfaces.Infrastructure;
using Domain.Models;
using Domain.Records.Requests;
using Infrastructure.Clients.Records;
using Microsoft.AspNetCore.WebUtilities;
using System.Net.Http.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Infrastructure.Clients
{
	public class BitconMarketClient : IBitconMarketClient
	{
		private readonly HttpClient _client;

		public BitconMarketClient(IHttpClientFactory httpClientFactory)
		{
			_client = httpClientFactory.CreateClient(nameof(BitconMarketClient));
		}

		public async Task<IEnumerable<Account>> GetAccountsAsync()
		{
			var response = await _client.GetAsync($"accounts");

			if (!response.IsSuccessStatusCode)
			{
				var error = await response.Content.ReadFromJsonAsync<BitcoinMarketErrorResponse>();
				throw new BitcoinMarketException(error!.Message);
			}

			var accounts = new List<Account>();
			await foreach (var account in response.Content.ReadFromJsonAsAsyncEnumerable<Account>())
			{
				accounts.Add(account!);
			}

			return accounts;

		}

		public async Task<IEnumerable<Order>> GetOrdersAsync(string accountId, string symbol, OrderQueryParams queryParams)
		{
			var baseUrl = $"accounts/{accountId}/{symbol}/orders/";
			var queryParameters = new Dictionary<string, string?>
			{
				["created_at_to"] = queryParams.CreatedAtTo.ToUnixTimestampString(),
				["created_at_from"] = queryParams.CreatedAtFrom.ToUnixTimestampString(),
			};

			var urlWithParams = QueryHelpers.AddQueryString(baseUrl, queryParameters);

			var response = await _client.GetAsync(baseUrl);

			if (!response.IsSuccessStatusCode)
			{
				var error = await response.Content.ReadFromJsonAsync<BitcoinMarketErrorResponse>();
				throw new BitcoinMarketException(error!.Message);
			}

			var orders = new List<Order>();
			await foreach (var order in response.Content.ReadFromJsonAsAsyncEnumerable<Order>())
			{
				orders.Add(order!);
			}

			return orders;

		}
	}
}
