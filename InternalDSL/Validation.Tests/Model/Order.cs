namespace Validation.Tests.Model
{
	using System;
	using System.Collections.Generic;

	public class Order
	{
		public string OrderId { get; set; }

		public Customer Customer { get; set; }

		public IList<OrderItem> Items { get; set; }

		public DateTime OrderDate { get; set; }
	}
}