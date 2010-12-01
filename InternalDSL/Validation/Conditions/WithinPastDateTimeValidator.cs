namespace Validation.Conditions
{
	using System;
	using System.Collections.Generic;
	using Impl;

	internal class WithinPastDateTimeValidator :
		Validator<DateTime>
	{
		readonly TimeSpan _period;
		string _periodText;

		public WithinPastDateTimeValidator(TimeSpan period)
		{
			_period = period;
			_periodText = _period.ToFriendlyString();
		}

		public IEnumerable<Violation> Validate(DateTime value)
		{
			DateTime now = value.Kind == DateTimeKind.Utc ? DateTime.UtcNow.Date : DateTime.Now.Date;
			DateTime past = now - _period;

			if (value.Date < past || value.Date > now)
				yield return new ViolationImpl<DateTime>("must be within the past " + _periodText);
		}
	}
}