namespace Validation.Tests
{
	using System.Collections.Generic;
	using System.Linq;
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

			List<Violation> violations = _validator.Validate(order).ToList();

			Assert.AreEqual(1, violations.Count);
		}
	}

	[TestFixture]
	public class NotEmpty_Tests
	{
		Validator<Order> _validator;

		[TestFixtureSetUp]
		public void Using_a_not_empty_and_not_null_validator_on_a_string_property()
		{
			_validator = Validator.New<Order>(x =>
				{
					x.Property(y => y.OrderId)
						.NotEmpty()
						.NotNull();
				});
		}

		[Test]
		public void Should_support_not_null()
		{
			var order = new Order {OrderId = null};

			List<Violation> violations = _validator.Validate(order).ToList();
			Assert.AreEqual(1, violations.Count);
			Assert.AreEqual("cannot be null", violations[0].Message);
		}

		[Test]
		public void Should_support_not_empty()
		{
			var order = new Order {OrderId = ""};

			List<Violation> violations = _validator.Validate(order).ToList();
			Assert.AreEqual(1, violations.Count);
			Assert.AreEqual("cannot be empty", violations[0].Message);
		}

		[Test]
		public void Should_not_violate_a_valid_string()
		{
			var order = new Order {OrderId = "a"};

			List<Violation> violations = _validator.Validate(order).ToList();
			Assert.AreEqual(0, violations.Count);
		}
	}
}