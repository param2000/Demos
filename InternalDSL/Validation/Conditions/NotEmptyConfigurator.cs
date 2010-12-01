namespace Validation.Conditions
{
	using System;
	using Impl;

	internal class NotEmptyConfigurator :
		Configurator<string>
	{
		public void Configure(ValidatorBuilder<string> builder)
		{
			var validator = new NotEmptyValidator();

			builder.AddValidator(validator);
		}

		public void ValidateConfiguration()
		{
		}
	}
}