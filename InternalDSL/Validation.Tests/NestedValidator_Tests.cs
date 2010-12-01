namespace Validation.Tests
{
	using System.Collections.Generic;
	using System.Linq;
	using Model;
	using NUnit.Framework;
	using Validation.Advanced;

	[TestFixture]
	public class NestedValidator_Tests
	{
		Validator<Order> _validator;

		[TestFixtureSetUp]
		public void Specifying_a_nested_validator_for_a_property()
		{
			var customerValidator = Validator.New<Customer>(x =>
				{
					x.NotNull();
					x.Property(y => y.Name)
						.NotNull()
						.NotEmpty();
				});

			_validator = Validator.New<Order>(x =>
				{
					x.Property(y => y.Customer)
						.ValidateWith(customerValidator);
				});
		}

		[Test]
		public void Should_catch_the_null_property()
		{
			var order = new Order();

			List<Violation> violations = _validator.Validate(order).ToList();

			Assert.AreEqual(1, violations.Count);
			Assert.AreEqual("cannot be null", violations[0].Message);
			Assert.AreEqual("Order.Customer", violations[0].Key);
			Assert.AreEqual("Order.Customer cannot be null", violations[0].ToString());
		}

		[Test]
		public void Should_catch_the_null_customer_name()
		{
			var order = new Order {Customer = new Customer()};

			List<Violation> violations = _validator.Validate(order).ToList();

			Assert.AreEqual(1, violations.Count);
			Assert.AreEqual("cannot be null", violations[0].Message);
			Assert.AreEqual("Order.Customer.Name", violations[0].Key);
			Assert.AreEqual("Order.Customer.Name cannot be null", violations[0].ToString());
		}

		[Test]
		public void Should_accept_a_valid_customer_value()
		{
			var order = new Order {Customer = new Customer {Name = "a"}};

			List<Violation> violations = _validator.Validate(order).ToList();

			Assert.AreEqual(0, violations.Count);
		}
	}
}