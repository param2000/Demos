namespace WebSite.Core.Data
{
	using System;
	using System.Data.SqlClient;

	public class ConnectionContext :
		IConnectionContext
	{
		private readonly ISqlConnectionFactory _connectionFactory;
		private SqlConnection _connection;
		private volatile bool _disposed;

		public ConnectionContext(ISqlConnectionFactory connectionFactory, string connectionStringName)
		{
			_connectionFactory = connectionFactory;
			ConnectionStringName = connectionStringName;
		}

		public string ConnectionStringName { get; set; }

		public SqlConnection Connection
		{
			get
			{
				if (_connection != null)
					return _connection;

				_connection = GetConnection();

				return _connection;
			}
		}


		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		~ConnectionContext()
		{
			Dispose(false);
		}

		public virtual void Dispose(bool disposing)
		{
			if (!disposing || _disposed) return;

			if (_connection != null)
			{
				_connection.Close();
				_connection.Dispose();
				_connection = null;
			}

			_disposed = true;
		}

		protected SqlConnection GetConnection()
		{
			return _connectionFactory.GetConnection(ConnectionStringName);
		}
	}
}