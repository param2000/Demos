namespace Validation
{
	public interface ValidatorBuilder
	{
	}

	public interface ValidatorBuilder<T> :
		ValidatorBuilder
	{
		void AddValidator(Validator<T> validator);
	}
}