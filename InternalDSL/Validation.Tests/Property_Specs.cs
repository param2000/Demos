namespace Validation.Tests
{
	using System.Collections.Generic;
	using System.Linq;
	using Model;
	using NUnit.Framework;

	[TestFixture]
	public class Property_Specs
	{
		Validator<Order> _validator;

		[TestFixtureSetUp]
		public void Should_be_able_to_create_a_validator_for_a_class()
		{
			_validator = Validator.New<Order>(x =>
				{
					x.Property(y => y.OrderId)
						.NotNull()
						.NotEmpty();
				});
		}

		[Test]
		public void Should_pass_with_no_conditions()
		{
			Order order = new Order();

			List<Violation> violations = _validator.Validate(order).ToList();

			Assert.AreEqual(1, violations.Count);
			Assert.AreEqual("cannot be null", violations[0].Message);
			Assert.AreEqual("Order.OrderId", violations[0].Key);
			Assert.AreEqual("Order.OrderId cannot be null", violations[0].ToString());
		}
	}

	[TestFixture]
	public class Property_Specs2
	{
		Validator<Order> _validator;

		[TestFixtureSetUp]
		public void Should_call_the_chained_validator_on_the_property()
		{
			_validator = Validator.New<Order>(x =>
				{
					x.Property(y => y.OrderId)
						.NotNull()
						.NotEmpty();
				});
		}

		[Test]
		public void Should_match_the_empty_string_value()
		{
			Order order = new Order();
			order.OrderId = "";

			List<Violation> violations = _validator.Validate(order).ToList();

			Assert.AreEqual(1, violations.Count);
			Assert.AreEqual("cannot be empty", violations[0].Message);
			Assert.AreEqual("Order.OrderId", violations[0].Key);
			Assert.AreEqual("Order.OrderId cannot be empty", violations[0].ToString());
		}
	}
}