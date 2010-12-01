namespace Validation.Conditions
{
	using System;
	using Impl;

	internal class DateTimeValidatorConfiguratorImpl :
		DateTimeValidatorConfigurator,
		Configurator<DateTime>
	{
		readonly ValidatorConfigurator<DateTime> _configurator;

		public DateTimeValidatorConfiguratorImpl(ValidatorConfigurator<DateTime> configurator)
		{
			_configurator = configurator;
		}

		public virtual void Configure(ValidatorBuilder<DateTime> builder)
		{
		}

		public virtual void ValidateConfiguration()
		{
		}

		public void AddConfigurator(Configurator<DateTime> configurator)
		{
			_configurator.AddConfigurator(configurator);
		}
	}
}