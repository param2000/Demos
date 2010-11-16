namespace Validation.Conditions
{
	using System;
	using System.Collections.Generic;
	using System.Linq.Expressions;

	public class PropertyValidator<T, TProperty> :
		Validator<T>
		where T : class
	{
		readonly Expression<Func<T, TProperty>> _propertyExpression;
		readonly Validator<TProperty> _valueValidator;
		Func<T, TProperty> _propertyAccessor;

		public PropertyValidator(Expression<Func<T, TProperty>> propertyExpression, Validator<TProperty> valueValidator)
		{
			_valueValidator = valueValidator;
			_propertyExpression = propertyExpression;

			_propertyAccessor = _propertyExpression.Compile();
		}

		public IEnumerable<Violation> Validate(T value)
		{
			if (value == null)
				yield break;

			TProperty propertyValue = _propertyAccessor(value);

			foreach (Violation violation in _valueValidator.Validate(propertyValue))
			{
				yield return violation;
			}
		}
	}
}