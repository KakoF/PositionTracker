
using Domain.Interfaces.Infrastructure;
using Domain.Interfaces.Services;
using Domain.Models;

namespace Application.Services
{
	public class AccountService : IAccountService
	{
		private readonly IBitconMarketClient _bitconMarketClient;
		public AccountService(IBitconMarketClient bitconMarketClient)
		{
			_bitconMarketClient = bitconMarketClient;
		}
		public async Task<IEnumerable<Account>> GetAsync()
		{
			return await _bitconMarketClient.GetAccountsAsync();
		}
	}
}
