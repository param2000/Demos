namespace Validation.Tests
{
	using System.Collections.Generic;
	using System.Linq;
	using Model;
	using NUnit.Framework;

	[TestFixture]
	public class When_valiating_a_string_starts_with
	{
		Validator<Order> _validator;

		[TestFixtureSetUp]
		public void Using_a_matches_expression()
		{
			_validator = Validator.New<Order>(x =>
				{
					x.Property(y => y.OrderId)
						.StartsWith("ABC");
				});
		}

		[Test]
		public void Should_accept_a_value_with_valid_characters()
		{
			var order = new Order {OrderId = "ABCDEFGHIJKLMNOPQRSTUVWXYZ"};

			List<Violation> violations = _validator.Validate(order).ToList();
			Assert.AreEqual(0, violations.Count);
		}

		[Test]
		public void Should_fail_with_a_null_value()
		{
			var order = new Order();

			List<Violation> violations = _validator.Validate(order).ToList();
			Assert.AreEqual(1, violations.Count);
			Assert.AreEqual("did not start with: ABC", violations[0].Message);
		}

		[Test]
		public void Should_not_match_a_value_with_invalid_characters()
		{
			var order = new Order {OrderId = "123"};

			List<Violation> violations = _validator.Validate(order).ToList();
			Assert.AreEqual(1, violations.Count);
			Assert.AreEqual("did not start with: ABC", violations[0].Message);
		}
	}

	[TestFixture]
	public class When_valiating_a_string_contains
	{
		Validator<Order> _validator;

		[TestFixtureSetUp]
		public void Using_a_matches_expression()
		{
			_validator = Validator.New<Order>(x =>
				{
					x.Property(y => y.OrderId)
						.Contains("LMNOP");
				});
		}

		[Test]
		public void Should_accept_a_value_with_valid_characters()
		{
			var order = new Order {OrderId = "ABCDEFGHIJKLMNOPQRSTUVWXYZ"};

			List<Violation> violations = _validator.Validate(order).ToList();
			Assert.AreEqual(0, violations.Count);
		}

		[Test]
		public void Should_fail_with_a_null_value()
		{
			var order = new Order();

			List<Violation> violations = _validator.Validate(order).ToList();
			Assert.AreEqual(1, violations.Count);
			Assert.AreEqual("did not contain: LMNOP", violations[0].Message);
		}

		[Test]
		public void Should_not_match_a_value_with_invalid_characters()
		{
			var order = new Order {OrderId = "123"};

			List<Violation> violations = _validator.Validate(order).ToList();
			Assert.AreEqual(1, violations.Count);
			Assert.AreEqual("did not contain: LMNOP", violations[0].Message);
		}
	}

	[TestFixture]
	public class When_valiating_a_string_ends_with
	{
		Validator<Order> _validator;

		[TestFixtureSetUp]
		public void Using_a_matches_expression()
		{
			_validator = Validator.New<Order>(x =>
				{
					x.Property(y => y.OrderId)
						.EndsWith("XYZ");
				});
		}

		[Test]
		public void Should_accept_a_value_with_valid_characters()
		{
			var order = new Order {OrderId = "ABCDEFGHIJKLMNOPQRSTUVWXYZ"};

			List<Violation> violations = _validator.Validate(order).ToList();
			Assert.AreEqual(0, violations.Count);
		}

		[Test]
		public void Should_fail_with_a_null_value()
		{
			var order = new Order();

			List<Violation> violations = _validator.Validate(order).ToList();
			Assert.AreEqual(1, violations.Count);
			Assert.AreEqual("did not end with: XYZ", violations[0].Message);
		}

		[Test]
		public void Should_not_match_a_value_with_invalid_characters()
		{
			var order = new Order {OrderId = "123"};

			List<Violation> violations = _validator.Validate(order).ToList();
			Assert.AreEqual(1, violations.Count);
			Assert.AreEqual("did not end with: XYZ", violations[0].Message);
		}
	}
}