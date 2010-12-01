namespace Validation
{
	using Conditions;
	using Impl;

	public static class StringValidatorExtensions
	{
		public static StringValidatorConfigurator StartsWith(this ValidatorConfigurator<string> configurator, string value)
		{
			var stringValidatorConfigurator = new StartsWithStringValidatorConfigurator(configurator, value);

			configurator.AddConfigurator(stringValidatorConfigurator);

			return stringValidatorConfigurator;
		}

		public static StringValidatorConfigurator EndsWith(this ValidatorConfigurator<string> configurator, string value)
		{
			var stringValidatorConfigurator = new EndsWithStringValidatorConfigurator(configurator, value);

			configurator.AddConfigurator(stringValidatorConfigurator);

			return stringValidatorConfigurator;
		}

		public static StringValidatorConfigurator Contains(this ValidatorConfigurator<string> configurator, string value)
		{
			var stringValidatorConfigurator = new ContainsStringValidatorConfigurator(configurator, value);

			configurator.AddConfigurator(stringValidatorConfigurator);

			return stringValidatorConfigurator;
		}
	}
}