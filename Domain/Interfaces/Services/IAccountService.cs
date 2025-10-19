
using Domain.Models;

namespace Domain.Interfaces.Services
{
	public interface IAccountService
	{
		Task<IEnumerable<Account>> GetAsync();
	}
}
