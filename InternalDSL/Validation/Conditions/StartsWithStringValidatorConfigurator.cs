namespace Validation.Conditions
{
	using Impl;

	internal class StartsWithStringValidatorConfigurator :
		StringValidatorConfiguratorImpl
	{
		readonly string _value;

		public StartsWithStringValidatorConfigurator(ValidatorConfigurator<string> configurator, string value)
			: base(configurator, x => x.StartsWith(value), "did not start with: " + value ?? "")
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