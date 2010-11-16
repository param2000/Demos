namespace Validation
{
	using System.Collections.Generic;
	using System.Linq;

	internal class ValidatorImpl<T> :
		Validator<T>
	{
		readonly IList<Validator<T>> _validators;

		public ValidatorImpl(IEnumerable<Validator<T>> validators)
		{
			_validators = validators.ToList();
		}

		public void Validate(T value)
		{
			foreach (var validator in _validators)
			{
				validator.Validate(value);
			}
		}
	}
}