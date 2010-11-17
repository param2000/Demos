namespace Validation.Conditions
{
	using System.Collections.Generic;
	using System.Text.RegularExpressions;
	using Impl;

	public class MatchesValidator :
		Validator<string>
	{
		readonly Regex _regex;

		public MatchesValidator(Regex regex)
		{
			_regex = regex;
		}

		public IEnumerable<Violation> Validate(string value)
		{
			bool result = _regex.IsMatch(value ?? "");

			if (!result)
				yield return new ViolationImpl<string>("did not match expression: " + _regex);
		}
	}
}