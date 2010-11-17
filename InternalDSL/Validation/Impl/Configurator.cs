namespace Validation.Impl
{
	public interface Configurator
	{
		void ValidateConfiguration();
	}

	public interface Configurator<in T> :
		Configurator
	{
		void Configure(ValidatorBuilder<T> builder);
	}
}