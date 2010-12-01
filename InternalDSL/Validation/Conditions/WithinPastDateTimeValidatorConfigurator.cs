namespace Validation.Conditions
{
	using System;
	using Impl;

	internal class WithinPastDateTimeValidatorConfigurator :
		DateTimeValidatorConfiguratorImpl
	{
		readonly TimeSpan _period;

		public WithinPastDateTimeValidatorConfigurator(ValidatorConfigurator<DateTime> configurator, TimeSpan period)
			: base(configurator)
		{
			_period = period;
		}

		public override void Configure(ValidatorBuilder<DateTime> builder)
		{
			var validator = new WithinPastDateTimeValidator(_period);

			builder.AddValidator(validator);
		}

		public override void ValidateConfiguration()
		{
			if (_period < TimeSpan.Zero)
				throw new ValidationException("The time span must be greater than or equal to zero");
		}
	}
}