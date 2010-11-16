namespace Validation
{
	using System;

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
		void Validate(T value);
	}
}