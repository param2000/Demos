namespace Validation.Impl
{
	public interface ValidatorConfigurator<T>
	{
		void AddConfigurator(Configurator<T> configurator);
	}
}