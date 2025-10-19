using Domain.Interfaces.Services;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class AccountController : ControllerBase
	{
		private readonly IAccountService _accountService;
		public AccountController(IAccountService accountService)
		{
			_accountService = accountService;
		}

		[HttpGet]
		public Task<IEnumerable<Account>> GetAsync()
		{
			return _accountService.GetAsync();
		}
	}
}
