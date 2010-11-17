namespace Validation.Impl
{
	public interface ValidatorConfigurator<out T>
	{
		void AddConfigurator(Configurator<T> configurator);
	}
}