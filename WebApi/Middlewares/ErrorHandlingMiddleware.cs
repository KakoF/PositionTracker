using Domain.Exceptions;
using Newtonsoft.Json;
using System.Net;

namespace WebApi.Middlewares
{
	public class ErrorHandlingMiddleware
	{
		private readonly RequestDelegate next;
		private readonly ILogger<ErrorHandlingMiddleware> _logger;

		public ErrorHandlingMiddleware(RequestDelegate next, ILogger<ErrorHandlingMiddleware> logger)
		{
			this.next = next;
			_logger = logger;
		}

		public async Task Invoke(HttpContext context)
		{
			try
			{
				await next(context);
			}
			catch (Exception ex)
			{
				await HandleExceptionAsync(context, ex);
			}
		}

		private Task HandleExceptionAsync(HttpContext context, Exception exception)
		{
			int code;
			ErrorResponse error;

			if (exception is DomainException)
			{
				var ex = (DomainException)exception;
				code = ex.StatusCode;
				error = new ErrorResponse(code, exception.Message);

				if (exception is BitcoinMarketException)
				{
					var httpEx = (BitcoinMarketException)exception;
					_logger.LogWarning(exception, httpEx.HttpErrorMessage);
				}
				else
				{
					_logger.LogWarning(exception, exception.Message);
				}

			}
			else
			{
				code = (int)HttpStatusCode.InternalServerError;
				error = new ErrorResponse(code);
				_logger.LogError(exception, exception.Message);
			}

			var result = JsonConvert.SerializeObject(error);
			context.Response.ContentType = "application/json";
			context.Response.StatusCode = (int)code;
			return context.Response.WriteAsync(result);
		}
	}
}