namespace Validation
{
	using System;
	using System.Collections.Generic;
	using Impl;

	public static class Validator
	{
		public static Validator<T> New<T>(Action<ValidatorConfigurator<T>> configure)
		{
			var configurator = new ValidatorConfiguratorImpl<T>();

			configure(configurator);

			return configurator.CreateValidator();
		}
	}


	public interface Validator<T>
	{
		IEnumerable<Violation> Validate(T value);
	}
}