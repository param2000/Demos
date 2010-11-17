namespace Validation
{
	using System.Collections.Generic;
	using Conditions;
	using Impl;

	public class EnumerableConfigurator<T, TElement> :
		Configurator<T>
		where T : class, IEnumerable<TElement>
	{
		readonly Configurator<TElement> _configurator;

		public EnumerableConfigurator(Configurator<TElement> configurator)
		{
			_configurator = configurator;
		}

		public void Configure(ValidatorBuilder<T> builder)
		{
			var elementBuilder = new TypeValidatorBuilder<TElement>();
			
			_configurator.Configure(elementBuilder);

			var elementValidator = elementBuilder.Build("");

			var nestedValidator = new NestedValidator<TElement>(elementValidator);

			var validator = new EnumerableValidator<T, TElement>(nestedValidator);

			builder.AddValidator(validator);
		}

		public void ValidateConfiguration()
		{
			if (_configurator == null)
				throw new ValidationException("The element configurator cannot be null");
		}
	}
}