namespace Validation
{
	public interface ValidatorConfigurator<T>
	{
		void AddConfigurator(Configurator<T> configurator);
	}
}