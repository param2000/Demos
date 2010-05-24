namespace WebSite.Core.Data
{
	using System;
	using System.Data.SqlClient;

	public interface IConnectionContext :
		IDisposable
	{
		SqlConnection Connection { get; }
	}
}