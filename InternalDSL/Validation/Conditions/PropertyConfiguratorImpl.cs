namespace Validation.Conditions
{
	using System;
	using System.Collections.Generic;
	using System.Linq.Expressions;
	using System.Reflection;
	using Impl;

	public class PropertyConfiguratorImpl<T, TProperty> :
		PropertyConfigurator<T, TProperty>,
		Configurator<T>
		where T : class
	{
		readonly Expression<Func<T, TProperty>> _propertyExpression;
		IList<Configurator<TProperty>> _configurators;

		public PropertyConfiguratorImpl(Expression<Func<T, TProperty>> propertyExpression)
		{
			_propertyExpression = propertyExpression;

			_configurators = new List<Configurator<TProperty>>();
		}

		public void Configure(ValidatorBuilder<T> builder)
		{
			var propertyValidatorBuilder= new ValidatorBuilderImpl<TProperty>();
			foreach (var configurator in _configurators)
			{
				configurator.Configure(propertyValidatorBuilder);
			}

			var propertyValueValidator = propertyValidatorBuilder.Build("." + GetPropertyName(_propertyExpression));

			var validator = new PropertyValidator<T, TProperty>(_propertyExpression, propertyValueValidator);

			builder.AddValidator(validator);
		}

		static string GetPropertyName(Expression<Func<T, TProperty>> propertyExpression)
		{
			Expression expression = propertyExpression.Body;
			var me = expression as MemberExpression;

			return me.Member.Name;
		}
		public void ValidateConfiguration()
		{
			Expression expression = _propertyExpression.Body;
			var me = expression as MemberExpression;
			if (me == null || me.Member.MemberType != MemberTypes.Property)
				throw new ValidationException("A property accessor must be specified: " + _propertyExpression);

			foreach (var configurator in _configurators)
			{
				configurator.ValidateConfiguration();
			}
		}

		public void AddConfigurator(Configurator<TProperty> configurator)
		{
			_configurators.Add(configurator);
		}
	}
}