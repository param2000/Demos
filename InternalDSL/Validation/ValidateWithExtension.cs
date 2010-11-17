namespace Validation
{
	using System.Collections.Generic;
	using Conditions;
	using Impl;

	public static class ValidateWithExtension
	{
		public static ValidatorConfigurator<T> ValidateWith<T>(this ValidatorConfigurator<T> configurator, Validator<T> validator)
		{
			var nestedConfigurator = new NestedConfigurator<T>(validator);

			configurator.AddConfigurator(nestedConfigurator);

			return configurator;
		}

		public static ValidatorConfigurator<IList<T>> ValidateWith<T>(this ValidatorConfigurator<IList<T>> configurator, Validator<T> validator)
		{
			var nestedConfigurator = new NestedConfigurator<T>(validator);

			var enumerableConfigurator = new EnumerableConfigurator<IList<T>, T>(nestedConfigurator);

			configurator.AddConfigurator(enumerableConfigurator);

			return configurator;
		}
	}
}