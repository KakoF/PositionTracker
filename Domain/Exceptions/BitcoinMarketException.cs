namespace Domain.Exceptions
{
	public class BitcoinMarketException : DomainException
	{
		public string HttpErrorMessage { get; private set; }

		public BitcoinMarketException(string message, int statusCode = 400) : base("Some error occurs in request Bitcoin Market", statusCode)
		{
			HttpErrorMessage = message;
		}

		public BitcoinMarketException(string message, Exception innerException, int statusCode = 400) : base("Some error occurs in request Bitcoin Market", innerException)
		{
			HttpErrorMessage = message;
		}
	}
}
