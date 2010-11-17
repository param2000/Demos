namespace Validation.Conditions
{
	using System.Text.RegularExpressions;
	using Advanced;
	using Impl;

	public class MatchesConfiguratorImpl :
		Configurator<string>,
		MatchesConfigurator
	{
		readonly ValidatorConfigurator<string> _configurator;
		readonly string _pattern;
		Regex _compiled;
		RegexOptions _options;

		public MatchesConfiguratorImpl(ValidatorConfigurator<string> configurator, string pattern)
		{
			_configurator = configurator;
			_pattern = pattern;
			_options = RegexOptions.Compiled;
		}

		public void Configure(ValidatorBuilder<string> builder)
		{
			var validator = new MatchesValidator(_compiled);

			builder.AddValidator(validator);
		}

		public void ValidateConfiguration()
		{
			_compiled = new Regex(_pattern, _options);
		}

		public void AddConfigurator(Configurator<string> configurator)
		{
			// this passes through since we are not modifying any chained configurations
			_configurator.AddConfigurator(configurator);
		}

		public MatchesConfigurator SingleLine()
		{
			_options = (_options & ~RegexOptions.Multiline) | RegexOptions.Singleline;

			return this;
		}
	}
}