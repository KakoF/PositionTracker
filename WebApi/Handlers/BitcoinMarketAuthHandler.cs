using Domain.Interfaces.Infrastructure;
using Infrastructure.Configurations;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;

namespace WebApi.Handlers
{
	public class BitcoinMarketAuthHandler : DelegatingHandler
	{
		private readonly IAuthBitconMarketClient _authBitconMarketClient;
		private readonly IMemoryCache _memoryCache;
		private readonly AuthBitcoinMarketConfiguration _config;
		public BitcoinMarketAuthHandler(IAuthBitconMarketClient authBitconMarketClient, IMemoryCache memoryCache, IOptions<AuthBitcoinMarketConfiguration> config)
		{
			_authBitconMarketClient = authBitconMarketClient;
			_memoryCache = memoryCache;
			_config = config.Value;
		}
		protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
		{
			var auth = await _memoryCache.GetOrCreateAsync($"auth:{_config.Id}", async entry => {
				entry.AbsoluteExpiration = DateTimeOffset.Now.AddMinutes(60);
				return await _authBitconMarketClient.AuthAsync(_config.Id, _config.Secret);
			});

			request.Headers.Add("Authorization", $"Bearer {auth!.AccessToken}");
			var response = await base.SendAsync(request, cancellationToken);
			return response;
		}
	}
}