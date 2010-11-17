namespace Validation.Conditions
{
	using System.Collections.Generic;
	using System.Linq;
	using Impl;

	public class NestedValidator<T> :
		Validator<T>
	{
		readonly Validator<T> _validator;

		public NestedValidator(Validator<T> validator)
		{
			_validator = validator;
		}

		public IEnumerable<Violation> Validate(T value)
		{
			return _validator.Validate(value).Select(TranslateViolation);
		}

		static Violation<T> TranslateViolation(Violation x)
		{
			string key = x.Key.Contains(".") ? x.Key.Substring(x.Key.IndexOf('.')) : "";

			return new ViolationImpl<T>(key, x.Message);
		}
	}
}