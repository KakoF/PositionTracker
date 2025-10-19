using Domain.Models;
using Domain.Records.Responses.Auth;

namespace Domain.Interfaces.Infrastructure
{
	public interface IAuthBitconMarketClient
	{
		Task<AuthResponse?> AuthAsync(string id, string secret);
	}
}
