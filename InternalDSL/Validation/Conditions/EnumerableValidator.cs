namespace Validation.Conditions
{
	using System.Collections.Generic;
	using System.Linq;
	using Impl;

	public class EnumerableValidator<T, TElement> :
		Validator<T>
		where T : class, IEnumerable<TElement>
	{
		readonly Validator<TElement> _elementValidator;

		public EnumerableValidator(Validator<TElement> elementValidator)
		{
			_elementValidator = elementValidator;
		}

		public IEnumerable<Violation> Validate(T value)
		{
			if (value == null)
				yield break;

			foreach (Violation violation in value.SelectMany((item, index) => _elementValidator
			                                                                  	.Validate(item)
			                                                                  	.Select(x => TranslateViolation(index, x))))
			{
				yield return violation;
			}
		}

		static Violation<T> TranslateViolation(int index, Violation x)
		{
			string key = "[" + index + "]" + x.Key;

			return new ViolationImpl<T>(key, x.Message);
		}
	}
}