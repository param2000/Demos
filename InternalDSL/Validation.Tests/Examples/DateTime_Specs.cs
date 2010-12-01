namespace Validation.Tests.Examples
{
	using System;
	using NUnit.Framework;

	[TestFixture]
	public class DateTime_Specs
	{
		[Test]
		public void FirstTestName()
		{
			var duration = 7.Seconds();

			DateTime expiration = 15.Seconds().FromNow();

			SetTimeout(12.Seconds());
		}

		[Test]
		public void Is_greater()
		{
			int left = 12;
			int right = 47;

			// This is pure fluent interface masturbation. Reading the C# language does this
			// much better than trying to hack this kind of crap together. It's purely an example
			// of how an interface can be used to constrain a generic extension method.
			if (12.IsGreaterThan(47))
			{

			}

			if (123.45m.IsGreaterThan(245.22m))
			{

			}

			if (right > left)
			{

			}
		}

		void SetTimeout(TimeSpan duration)
		{

		}
	}

	public static class intExtensions
	{
		public static TimeSpan Seconds(this int value)
		{
			return TimeSpan.FromSeconds(value);
		}

		public static bool IsGreaterThan<T>(this T value, T lowerLimit)
			where T : IComparable<T>
		{
			return value.CompareTo(lowerLimit) > 0;
		}

		public static DateTime FromNow(this TimeSpan value)
		{
			return DateTime.Now + value;
		}
	}
}
