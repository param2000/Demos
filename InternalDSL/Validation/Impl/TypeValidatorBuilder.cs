namespace Validation.Impl
{
	using System.Collections.Generic;

	internal class TypeValidatorBuilder<T> :
		ValidatorBuilder<T>
	{
		IList<Validator<T>> _validators;

		public TypeValidatorBuilder()
		{
			_validators = new List<Validator<T>>();
		}

		public void AddValidator(Validator<T> validator)
		{
			_validators.Add(validator);
		}

		public Validator<T> Build(string name)
		{
			return new TypeValidator<T>(name, _validators);
		}
	}
}