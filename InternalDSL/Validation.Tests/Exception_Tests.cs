namespace Validation.Tests
{
	using Model;
	using NUnit.Framework;

	[TestFixture]
	public class Exception_Tests
	{
		Validator<Order> _validator;

		[TestFixtureSetUp]
		public void Using_a_not_empty_and_not_null_validator_on_a_string_property()
		{
			_validator = Validator.New<Order>(x => { x.NotNull(); });
		}

		[Test]
		public void Should_support_not_null()
		{
			Order order = null;

			Assert.Throws<ViolationException>(() => _validator.Validate(order).ThrowIfInvalid());
		}
	}
}