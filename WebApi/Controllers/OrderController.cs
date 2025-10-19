using Domain.Interfaces.Services;
using Domain.Models;
using Domain.Records.Requests;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class OrderController : ControllerBase
	{
		private readonly IOrderService _orderService;
		public OrderController(IOrderService orderService)
		{
			_orderService = orderService;
		}

		[HttpGet("{accountId}/{symbol}/orders")]
		public Task<IEnumerable<Order>> GetAsync(string accountId, string symbol, [FromQuery] OrderQueryParams queryParams)
		{
			return _orderService.GetAsync(accountId, symbol, queryParams);
		}
	}
}
