namespace Validation.Impl
{
	using System.Collections.Generic;

	internal class TypeValidatorConfigurator<T> :
		ValidatorConfigurator<T>
	{
		readonly IList<Configurator<T>> _configurators;

		public TypeValidatorConfigurator()
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

			var builder = new TypeValidatorBuilder<T>();

			foreach (var configurator in _configurators)
			{
				configurator.Configure(builder);
			}

			return builder.Build(typeof(T).Name);
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