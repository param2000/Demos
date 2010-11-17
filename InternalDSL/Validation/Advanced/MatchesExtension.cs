namespace Validation.Advanced
{
	using Conditions;
	using Impl;

	public static class MatchesExtension
	{
		public static MatchesConfigurator Matches(this ValidatorConfigurator<string> configurator, string pattern)
		{
			var matchesConfigurator = new MatchesConfiguratorImpl(configurator, pattern);

			configurator.AddConfigurator(matchesConfigurator);

			return matchesConfigurator;
		}
	}
}