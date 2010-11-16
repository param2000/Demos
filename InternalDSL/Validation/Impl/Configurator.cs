namespace Validation.Impl
{
	public interface Configurator
	{
		void ValidateConfiguration();
	}

	public interface Configurator<T> :
		Configurator
	{
		void Configure(ValidatorBuilder<T> builder);
	}
}