namespace Validation.Conditions
{
	internal class NotNullConfigurator<T> :
		Configurator<T>
		where T : class
	{
		public void Configure(ValidatorBuilder<T> builder)
		{
			var validator = new NotNullValidator<T>();

			builder.AddValidator(validator);
		}

		public void ValidateConfiguration()
		{
		}
	}
}