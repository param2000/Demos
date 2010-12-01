namespace Validation
{
	using System;
	using System.Collections.Generic;

	public static class DateTimeExtensions
	{
		public static TimeSpan Days(this int value)
		{
			return TimeSpan.FromDays(value);
		}

		public static string ToFriendlyString(this TimeSpan ts)
		{
			if (ts.Equals(TimeSpan.FromDays(30)))
				return "month";
			if (ts.Equals(TimeSpan.FromDays(365)))
				return "year";
			if (ts.Equals(TimeSpan.FromDays(1)))
				return "day";
			if (ts.Equals(TimeSpan.FromHours(1)))
				return "hour";

			int years = ts.Days/365;
			int months = (ts.Days%365)/30;
			int weeks = ((ts.Days%365)%30)/7;
			int days = (((ts.Days%365)%30)%7);

			var parts = new List<string>();

			if (years > 1)
				parts.Add(years + " years");
			else if (years > 0)
				parts.Add(years + " year");

			if (months > 1)
				parts.Add(months + " months");
			else if (months > 0)
				parts.Add(months + " month");

			if (weeks > 1)
				parts.Add(weeks + " weeks");
			else if (weeks > 0)
				parts.Add(weeks + " week");

			if (days > 1)
				parts.Add(days + " days");
			else if (days > 0)
				parts.Add(days + " day");

			return String.Join(", ", parts);
		}
	}
}