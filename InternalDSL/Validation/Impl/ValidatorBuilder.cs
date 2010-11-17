namespace Validation.Impl
{
	public interface ValidatorBuilder
	{
	}

	public interface ValidatorBuilder<out T> :
		ValidatorBuilder
	{
		void AddValidator(Validator<T> validator);
	}
}