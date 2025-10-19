using Domain.Exceptions;
using Domain.Interfaces.Infrastructure;
using Domain.Records.Responses.Auth;
using Infrastructure.Clients.Records;
using System.Net.Http.Json;

namespace Infrastructure.Clients
{
	public class AuthBitconMarketClient : IAuthBitconMarketClient
	{
		private readonly HttpClient _client;

		public AuthBitconMarketClient(IHttpClientFactory httpClientFactory)
		{
			_client = httpClientFactory.CreateClient(nameof(AuthBitconMarketClient));
		}

		public async Task<AuthResponse?> AuthAsync(string id, string secret)
		{
			var response = await _client.PostAsJsonAsync(requestUri : "", new { Login = id, Password = secret });
			if (!response.IsSuccessStatusCode)
			{
				var error = await response.Content.ReadFromJsonAsync<BitcoinMarketErrorResponse>();
				throw new BitcoinMarketException(error!.Message);
			}
			return await response.Content.ReadFromJsonAsync<AuthResponse>();
		}

	}
}
