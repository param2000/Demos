namespace Validation
{
	using System.Collections.Generic;

	internal class ValidatorConfiguratorImpl<T> :
		ValidatorConfigurator<T>
	{
		readonly IList<Configurator<T>> _configurators;

		public ValidatorConfiguratorImpl()
		{
			_configurators = new List<Configurator<T>>();
		}

		public void AddConfigurator(Configurator<T> configurator)
		{
			_configurators.Add(configurator);
		}

		public Validator<T> CreateValidator()
		{
			ValidateConfigurators();

			var builder = new ValidatorBuilderImpl<T>();

			foreach (var configurator in _configurators)
			{
				configurator.Configure(builder);
			}

			return builder.Build();
		}

		void ValidateConfigurators()
		{
			foreach (var configurator in _configurators)
			{
				configurator.ValidateConfiguration();
			}
		}
	}
}