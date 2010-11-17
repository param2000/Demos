namespace Validation.Conditions
{
	using System.Collections.Generic;
	using Impl;

	public class NotEmptyListValidator<T> :
		Validator<IList<T>>
	{
		public IEnumerable<Violation> Validate(IList<T> value)
		{
			if (value != null && value.Count == 0)
				yield return new ViolationImpl<string>("cannot be empty");
		}
	}
}