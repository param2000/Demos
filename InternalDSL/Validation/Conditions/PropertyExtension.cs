namespace Validation
{
	using System;
	using System.Linq.Expressions;
	using Conditions;
	using Impl;

	public static class PropertyExtension
	{
		public static PropertyConfigurator<T, TProperty> Property<T, TProperty>(this ValidatorConfigurator<T> configurator,
		                                                                        Expression<Func<T, TProperty>> propertyExpression)
			where T : class
		{
			var propertyConfigurator = new PropertyConfiguratorImpl<T, TProperty>(propertyExpression);

			configurator.AddConfigurator(propertyConfigurator);

			return propertyConfigurator;
		}
	}
}