using Newtonsoft.Json;

namespace WebApi.Middlewares
{
	public class ErrorResponse
	{
		public int StatusCode { get; }
		[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
		public string Message { get; }
		
		public ErrorResponse(int statusCode, string? message = null)
		{
			StatusCode = statusCode;
			Message = message ?? GetDefaultMessageForStatusCode(statusCode);
		}
		private static string GetDefaultMessageForStatusCode(int statusCode)
		{
			switch (statusCode)
			{
				case 401:
					return "Unauthorized";
				case 403:
					return "Forbidden";
				case 404:
					return "Not Found";
				case 405:
					return "Not Allowed";
				default:
					return "Internal Server Error";
			}
		}
	}
}