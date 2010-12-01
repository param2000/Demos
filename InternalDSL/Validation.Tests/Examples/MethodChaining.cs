namespace Validation.Tests.Examples
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using NUnit.Framework;

	[TestFixture]
	public class MethodChaining
	{
		[Test]
		public void Using_linq()
		{
			IList<Product> products = new List<Product>();


			products
				.Where(p => p.Manufacturer == "Rossom");


			products
				.Where(p => p.ReleaseDate <= DateTime.Now);
		}



		[Test]
		public void Type_changing()
		{
			IList<Product> products = new List<Product>();


			products
				.Select(p => p.Manufacturer);

		}




		class Product
		{
			public string Manufacturer { get; set; }
			public DateTime ReleaseDate { get; set; }
		}

	}
}
