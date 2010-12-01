namespace Validation.Tests.Examples
{
	using System;
	using NUnit.Framework;

	[TestFixture]
	public class MethodChain_AreWeDone
	{
		[Test]
		public void Are_we_done()
		{
			Result result = new Configurator()
				.ForCustomer("Johnson")
				.ForUser("Bill");
		}

		/// <summary>
		/// This is a naive implementation of a fluent interface. It's doubtful this actually
		/// adds value beyond using a class initializer or something else. This is an example
		/// of a very early internal DSL, certainly not something that I would do today.
		/// </summary>
		class Configurator
		{
			string _customerName;
			string _userName;

			public Configurator ForCustomer(string customerName)
			{
				_customerName = customerName;

				return this;
			}

			public Configurator ForUser(string userName)
			{
				_userName = userName;

				return this;
			}


			public Result ToResult()
			{
				Result result = this;

				return result;
			}

			/// <summary>
			/// This is an extremely difficult to discover way of invoking a builder creating
			/// one class from another class. Complexity is very high and confusion surrounding
			/// this language feature make this a no-no for DSL/builder interactions.
			/// </summary>
			/// <param name="configurator"></param>
			/// <returns></returns>
			public static implicit operator Result(Configurator configurator)
			{
				// so now I have to validate?

				configurator.Validate();

				return new Result(configurator._customerName, configurator._userName);
			}

			void Validate()
			{
				if (string.IsNullOrEmpty(_customerName))
					throw new ArgumentNullException("customerName");

				if (string.IsNullOrEmpty(_userName))
					throw new ArgumentNullException("userName");
			}
		}

		class Result
		{
			public Result(string customerName, string userName)
			{
				CustomerName = customerName;
				UserName = userName;
			}

			public string CustomerName { get; private set; }
			public string UserName { get; private set; }
		}
	}
}
