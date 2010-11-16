namespace Validation.Tests
{
	using Model;
	using NUnit.Framework;

	[TestFixture]
	public class NotNull_Specs
	{
		Validator<Order> _validator;

		[TestFixtureSetUp]
		public void Should_be_able_to_create_a_validator_for_a_class()
		{
			_validator = Validator.New<Order>(x =>
				{
					// do not allow null values
					x.NotNull();
				});
		}

		[Test]
		public void Should_pass_with_no_conditions()
		{
			Order order = null;

			Assert.Throws<ValidationException>(() => _validator.Validate(order));
		}
	}
}