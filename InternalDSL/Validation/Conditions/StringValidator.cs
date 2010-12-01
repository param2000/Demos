namespace Validation.Conditions
{
	using System;
	using System.Collections.Generic;
	using Impl;

	public class StringValidator :
		Validator<string>
	{
		readonly string _message;
		readonly Func<string, bool> _validate;

		public StringValidator(Func<string, bool> validate, string message)
		{
			_validate = validate;
			_message = message;
		}

		public IEnumerable<Violation> Validate(string value)
		{
			if (_validate(value ?? ""))
				yield break;

			yield return new ViolationImpl<string>(_message);
		}
	}
}