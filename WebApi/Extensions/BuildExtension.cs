using Application.Services;
using Domain.Interfaces.Infrastructure;
using Domain.Interfaces.Services;
using Infrastructure.Clients;
using Infrastructure.Configurations;
using WebApi.Handlers;

namespace WebApi.Extensions
{
	public static class BuildExtension
	{

		public static void AddConfigurations(this WebApplicationBuilder builder)
		{
			builder.Services.Configure<AuthBitcoinMarketConfiguration>(builder.Configuration.GetSection("Clients:BitconMarketClient"));
		}

		public static void AddServices(this WebApplicationBuilder builder)
		{
			builder.Services.AddMemoryCache();
			builder.Services.AddHttpClient();
			builder.Services.AddScoped<BitcoinMarketAuthHandler>();
			builder.Services.AddScoped<IAccountService, AccountService>();
			builder.Services.AddScoped<IOrderService, OrderService>();
			builder.Services.AddScoped<IBitconMarketClient, BitconMarketClient>();
			builder.Services.AddScoped<IAuthBitconMarketClient, AuthBitconMarketClient>();


		}

		public static void AddClients(this WebApplicationBuilder builder)
		{

			builder.Services.AddHttpClient(nameof(AuthBitconMarketClient), client =>
			{
				client.BaseAddress = new Uri(builder.Configuration["Clients:BitconMarketClient:AuthPath"]!);
			}); 
			
			builder.Services.AddHttpClient(nameof(BitconMarketClient), client =>
			{
				client.BaseAddress = new Uri(builder.Configuration["Clients:BitconMarketClient:BasePath"]!);
			}).AddHttpMessageHandler<BitcoinMarketAuthHandler>();
		}
	}
}
