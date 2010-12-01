namespace Validation
{
	using System;
	using Conditions;
	using Impl;

	public static class DateTimeValidatorExtensions
	{
		public static DateTimeValidatorConfigurator WithinPast(this ValidatorConfigurator<DateTime> configurator, TimeSpan period)
		{
			var dateTimeValidator = new WithinPastDateTimeValidatorConfigurator(configurator, period);

			configurator.AddConfigurator(dateTimeValidator);

			return dateTimeValidator;
		}
	}
}