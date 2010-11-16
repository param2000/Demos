namespace Validation
{
	using Conditions;
	using Impl;

	public static class NotEmptyExtension
	{
		public static ValidatorConfigurator<string> NotEmpty(this ValidatorConfigurator<string> configurator)
		{
			var notEmptyConfigurator = new NotEmptyConfigurator();

			configurator.AddConfigurator(notEmptyConfigurator);

			return configurator;
		}
	}
}