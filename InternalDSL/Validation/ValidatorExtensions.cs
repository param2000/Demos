namespace Validation
{
	using System.Collections.Generic;

	public static class ValidatorExtensions
	{
		public static void ThrowIfInvalid(this IEnumerable<Violation> violations)
		{
			throw new ViolationException(violations);
		}
	}
}