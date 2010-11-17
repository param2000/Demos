namespace Validation.Advanced
{
	using Impl;

	public interface MatchesConfigurator :
		ValidatorConfigurator<string>
	{
		MatchesConfigurator SingleLine();
	}
}