namespace Validation.Conditions
{
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