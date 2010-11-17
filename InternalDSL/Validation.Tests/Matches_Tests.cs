namespace Validation.Tests
{
	using System.Collections.Generic;
	using System.Linq;
	using Advanced;
	using Model;
	using NUnit.Framework;

	[TestFixture]
	public class Matches_Tests
	{
		Validator<Order> _validator;

		[TestFixtureSetUp]
		public void Using_a_matches_expression()
		{
			_validator = Validator.New<Order>(x =>
				{
					x.Property(y => y.OrderId)
						.Matches("^[a-zA-Z]{1,40}$")
						.SingleLine()
						.NotEmpty();
				});
		}

		[Test]
		public void Should_not_match_a_value_with_invalid_characters()
		{
			var order = new Order {OrderId = "DEX20101001001"};

			List<Violation> violations = _validator.Validate(order).ToList();
			Assert.AreEqual(1, violations.Count);
			Assert.AreEqual("did not match expression: ^[a-zA-Z]{1,40}$", violations[0].Message);
		}

		[Test]
		public void Should_fail_with_a_null_value()
		{
			var order = new Order();

			List<Violation> violations = _validator.Validate(order).ToList();
			Assert.AreEqual(1, violations.Count);
			Assert.AreEqual("did not match expression: ^[a-zA-Z]{1,40}$", violations[0].Message);
		}

		[Test]
		public void Should_accept_a_value_with_valid_characters()
		{
			var order = new Order {OrderId = "ABCDEFGHIJKLMNOPQRSTUVWXYZ"};

			List<Violation> violations = _validator.Validate(order).ToList();
			Assert.AreEqual(0, violations.Count);
		}
	}
}
