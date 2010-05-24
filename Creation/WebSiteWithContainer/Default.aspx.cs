namespace WebSiteWithContainer
{
	using System;
	using System.Collections.Generic;
	using System.Data;
	using System.Data.SqlClient;
	using WebSite.Core.Data;

	public partial class _Default :
		PageBase<_Default>
	{
		protected List<string> Values;
		public IConnectionContext ConnectionContext { get; set; }

		protected void Page_Load(object sender, EventArgs e)
		{
			using (var command = new SqlCommand("SELECT * FROM SubscriptionSaga", ConnectionContext.Connection))
			{
				using (IDataReader results = command.ExecuteReader())
				{
					Values = new List<string>();
					while (results.Read())
					{
						Values.Add(results["MessageName"].ToString());
					}
				}
			}
		}
	}
}