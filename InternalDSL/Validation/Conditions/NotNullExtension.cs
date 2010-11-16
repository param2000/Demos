namespace Validation
{
	using Conditions;

	public static class NotNullExtension
	{
		public static void NotNull<T>(this ValidatorConfigurator<T> configurator)
			where T : class
		{
			var notNullConfigurator = new NotNullConfigurator<T>();

			configurator.AddConfigurator(notNullConfigurator);
		}
	}
}