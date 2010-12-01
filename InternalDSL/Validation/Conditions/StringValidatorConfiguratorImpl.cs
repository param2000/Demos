namespace Validation.Conditions
{
	using System;
	using Impl;

	internal class StringValidatorConfiguratorImpl :
		StringValidatorConfigurator,
		Configurator<string>
	{
		readonly ValidatorConfigurator<string> _configurator;
		readonly string _message;
		readonly Func<string, bool> _validate;

		protected StringValidatorConfiguratorImpl(ValidatorConfigurator<string> configurator, Func<string, bool> validate, string message)
		{
			_configurator = configurator;
			_validate = validate;
			_message = message;
		}

		public void Configure(ValidatorBuilder<string> builder)
		{
			var validator = new StringValidator(_validate, _message);

			builder.AddValidator(validator);
		}

		public virtual void ValidateConfiguration()
		{
		}

		public void AddConfigurator(Configurator<string> configurator)
		{
			_configurator.AddConfigurator(configurator);
		}
	}
}