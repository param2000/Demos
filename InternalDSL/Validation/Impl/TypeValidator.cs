namespace Validation.Impl
{
	using System.Collections.Generic;
	using System.Linq;

	internal class TypeValidator<T> :
		Validator<T>
	{
		readonly string _name;
		readonly IList<Validator<T>> _validators;

		public TypeValidator(string name, IEnumerable<Validator<T>> validators)
		{
			_name = name;
			_validators = validators.ToList();
		}

		public IEnumerable<Violation> Validate(T value)
		{
			foreach (var validator in _validators)
			{
				foreach (Violation violation in validator.Validate(value))
				{
					yield return new ViolationImpl<T>(_name + violation.Key, violation.Message);
				}
			}
		}
	}
}