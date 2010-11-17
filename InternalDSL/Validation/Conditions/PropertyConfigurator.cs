namespace Validation.Conditions
{
	using Impl;

	public interface PropertyConfigurator<out T, out TProperty> :
		ValidatorConfigurator<TProperty>
	{
	}
}