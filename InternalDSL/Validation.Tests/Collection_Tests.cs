namespace Validation.Tests
{
	using System.Collections.Generic;
	using System.Linq;
	using Model;
	using NUnit.Framework;

	[TestFixture]
	public class Collection_Tests
	{
		Validator<Order> _validator;

		[TestFixtureSetUp]
		public void Validating_a_property_that_is_a_collection()
		{
			var itemValidator = Validator.New<OrderItem>(x =>
				{
					x.NotNull();
				});

			_validator = Validator.New<Order>(x =>
				{
					x.Property(y => y.Items)
						.NotNull()
						.NotEmpty()
						.ValidateWith(itemValidator);
				});
		}

		[Test]
		public void Should_catch_an_empty_collection()
		{
			var order = new Order();
			order.Items = new List<OrderItem>();

			List<Violation> violations = _validator.Validate(order).ToList();

			Assert.AreEqual(1, violations.Count);
			Assert.AreEqual("cannot be empty", violations[0].Message);
			Assert.AreEqual("Order.Items", violations[0].Key);
			Assert.AreEqual("Order.Items cannot be empty", violations[0].ToString());
		}

		[Test]
		public void Should_pass_a_valid_object()
		{
			var order = new Order();
			order.Items = new List<OrderItem>();
			order.Items.Add(new OrderItem());

			List<Violation> violations = _validator.Validate(order).ToList();

			Assert.AreEqual(0, violations.Count);
		}

		[Test]
		public void Should_catch_a_null_element_in_the_list()
		{
			var order = new Order();
			order.Items = new List<OrderItem>();
			order.Items.Add(null);

			List<Violation> violations = _validator.Validate(order).ToList();

			Assert.AreEqual(1, violations.Count);
			Assert.AreEqual("cannot be null", violations[0].Message);
			Assert.AreEqual("Order.Items[0]", violations[0].Key);
			Assert.AreEqual("Order.Items[0] cannot be null", violations[0].ToString());
		}
	}
}