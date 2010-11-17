namespace Validation
{
	using System.Collections.Generic;
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

		public static ValidatorConfigurator<IList<T>> NotEmpty<T>(this ValidatorConfigurator<IList<T>> configurator)
		{
			var notEmptyConfigurator = new NotEmptyListConfigurator<T>();

			configurator.AddConfigurator(notEmptyConfigurator);

			return configurator;
		}
	}
}