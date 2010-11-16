namespace Validation.Conditions
{
	public class NotNullValidator<T> :
		Validator<T>
		where T : class
	{
		public void Validate(T value)
		{
			if (value == null)
				throw new ValidationException("The value cannot be null.");
		}
	}
}

namespace Validation
{
}