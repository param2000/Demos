namespace Validation.Conditions
{
	using System.Collections.Generic;
	using Impl;

	public class NotNullValidator<T> :
		Validator<T>
		where T : class
	{
		public IEnumerable<Violation> Validate(T value)
		{
			if (value == null)
				yield return new ViolationImpl<T>("cannot be null");
		}
	}
}