namespace Domain.Extensions
{
	public static class DateTimeExtensions
	{
		public static string? ToUnixTimestampString(this DateTime? date)
		{
			if (date.HasValue)
			{
				return new DateTimeOffset(date.Value).ToUnixTimeSeconds().ToString();
			}

			return null;
		}
	}

}
