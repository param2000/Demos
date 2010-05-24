namespace WebSite.Core.Data
{
	using System.Data.SqlClient;

	public interface ISqlConnectionFactory
	{
		SqlConnection GetConnection(string connectionName);
	}
}