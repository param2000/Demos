namespace Validation.Conditions
{
	using System.Collections.Generic;
	using Impl;

	public class NotEmptyValidator :
		Validator<string>
	{
		public IEnumerable<Violation> Validate(string value)
		{
			if (value != null && value.Length == 0)
				yield return new ViolationImpl<string>("cannot be empty");
		}
	}
}