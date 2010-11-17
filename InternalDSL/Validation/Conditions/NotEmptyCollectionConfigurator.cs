namespace Validation.Conditions
{
	using System.Collections.Generic;
	using Impl;

	internal class NotEmptyListConfigurator<T> :
		Configurator<IList<T>>
	{
		public void Configure(ValidatorBuilder<IList<T>> builder)
		{
			var validator = new NotEmptyListValidator<T>();

			builder.AddValidator(validator);
		}

		public void ValidateConfiguration()
		{
		}
	}
}