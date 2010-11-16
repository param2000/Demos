namespace Validation.Tests
{
	using Model;
	using NUnit.Framework;

	[TestFixture]
	public class Validation_tests
	{
		Validator<Order> _validator;

		[TestFixtureSetUp]
		public void Should_be_able_to_create_a_validator_for_a_class()
		{
			_validator = Validator.New<Order>(x =>
				{
					// No Conditions Specified
				});
		}

		[Test]
		public void Should_pass_with_no_conditions()
		{
			Order order = null;

			_validator.Validate(order);
		}
	}
}