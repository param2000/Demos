namespace Validation
{
	using System.Collections.Generic;

	internal class ValidatorBuilderImpl<T> :
		ValidatorBuilder<T>
	{
		IList<Validator<T>> _validators;

		public ValidatorBuilderImpl()
		{
			_validators = new List<Validator<T>>();
		}

		public void AddValidator(Validator<T> validator)
		{
			_validators.Add(validator);
		}

		public Validator<T> Build()
		{
			return new ValidatorImpl<T>(_validators);
		}
	}
}