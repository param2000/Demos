namespace Validation.Conditions
{
	using Impl;

	public class NestedConfigurator<T> :
		Configurator<T>
	{
		readonly Validator<T> _nestedValidator;

		public NestedConfigurator(Validator<T> nestedValidator)
		{
			_nestedValidator = nestedValidator;
		}

		public void Configure(ValidatorBuilder<T> builder)
		{
			var validator = new NestedValidator<T>(_nestedValidator);

			builder.AddValidator(validator);
		}

		public void ValidateConfiguration()
		{
			if (_nestedValidator == null)
				throw new ValidationException("Nested validator cannot be null");
		}
	}
}