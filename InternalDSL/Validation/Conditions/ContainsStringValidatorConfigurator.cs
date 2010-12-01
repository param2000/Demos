namespace Validation.Conditions
{
	using Impl;

	internal class ContainsStringValidatorConfigurator :
		StringValidatorConfiguratorImpl
	{
		readonly string _value;

		public ContainsStringValidatorConfigurator(ValidatorConfigurator<string> configurator, string value)
			: base(configurator, x => x.Contains(value), "did not contain: " + value ?? "")
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