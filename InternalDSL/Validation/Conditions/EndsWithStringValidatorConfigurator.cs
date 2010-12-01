namespace Validation.Conditions
{
	using Impl;

	internal class EndsWithStringValidatorConfigurator :
		StringValidatorConfiguratorImpl
	{
		readonly string _value;

		public EndsWithStringValidatorConfigurator(ValidatorConfigurator<string> configurator, string value)
			: base(configurator, x => x.EndsWith(value), "did not end with: " + value ?? "")
		{
			_value = value;
		}

		public override void ValidateConfiguration()
		{
			if (string.IsNullOrEmpty(_value))
				throw new ValidationException("A string value must be specified");

			base.ValidateConfiguration();
		}
	}
}