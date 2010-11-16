namespace Validation
{
	using Conditions;
	using Impl;

	public static class NotNullExtension
	{
		public static ValidatorConfigurator<T> NotNull<T>(this ValidatorConfigurator<T> configurator)
			where T : class
		{
			var notNullConfigurator = new NotNullConfigurator<T>();

			configurator.AddConfigurator(notNullConfigurator);

			return configurator;
		}
	}
}