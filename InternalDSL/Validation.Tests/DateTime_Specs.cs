namespace Validation.Tests
{
	using System.Collections.Generic;
	using System.Linq;
	using Model;
	using NUnit.Framework;

	[TestFixture]
	public class When_validating_datetime_fields
	{
		Validator<Order> _validator;

		[TestFixtureSetUp]
		public void Should_be_able_to_create_a_validator_for_a_class()
		{
			_validator = Validator.New<Order>(x =>
				{
					x.Property(y => y.OrderDate)
						.WithinPast(30.Days());
				});
		}

		[Test]
		public void Should_pass_with_no_conditions()
		{
			Order order = new Order();

			List<Violation> violations = _validator.Validate(order).ToList();

			Assert.AreEqual(1, violations.Count);
			Assert.AreEqual("must be within the past month", violations[0].Message);
			Assert.AreEqual("Order.OrderDate", violations[0].Key);
			Assert.AreEqual("Order.OrderDate must be within the past month", violations[0].ToString());
		}
	}

	[TestFixture]
	public class When_validating_datetime_fields_really_long
	{
		Validator<Order> _validator;

		[TestFixtureSetUp]
		public void Should_be_able_to_create_a_validator_for_a_class()
		{
			_validator = Validator.New<Order>(x =>
				{
					x.Property(y => y.OrderDate)
						.WithinPast(435.Days());
				});
		}

		[Test]
		public void Should_pass_with_no_conditions()
		{
			Order order = new Order();

			List<Violation> violations = _validator.Validate(order).ToList();

			Assert.AreEqual(1, violations.Count);
			Assert.AreEqual("must be within the past 1 year, 2 months, 1 week, 3 days", violations[0].Message);
			Assert.AreEqual("Order.OrderDate", violations[0].Key);
			Assert.AreEqual("Order.OrderDate must be within the past 1 year, 2 months, 1 week, 3 days", violations[0].ToString());
		}
	}
}