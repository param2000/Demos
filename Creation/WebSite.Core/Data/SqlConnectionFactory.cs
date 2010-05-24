namespace WebSite.Core.Data
{
	using System.Configuration;
	using System.Data.SqlClient;
	using System.Reflection;

	public class SqlConnectionFactory :
		ISqlConnectionFactory
	{
		public SqlConnection GetConnection(string connectionName)
		{
			return CreateConnection(GetConnectionString(connectionName));
		}

		private static string GetConnectionString(string connectionName)
		{
			ConnectionStringSettings connectionSettings = ConfigurationManager.ConnectionStrings[connectionName];
			if (connectionSettings == null)
				connectionSettings = GetConnectionSettingsFromAssemblyConfiguration(connectionName);

			if (connectionSettings == null)
				throw new ConfigurationErrorsException("There are no configuration string configured");

			return connectionSettings.ConnectionString;
		}

		private static ConnectionStringSettings GetConnectionSettingsFromAssemblyConfiguration(string connectionName)
		{
			var map = new ExeConfigurationFileMap
				{
					ExeConfigFilename = Assembly.GetExecutingAssembly().Location + ".config"
				};

			Configuration config = ConfigurationManager.OpenMappedExeConfiguration(map, ConfigurationUserLevel.None);

			return config.ConnectionStrings.ConnectionStrings[connectionName];
		}

		private static SqlConnection CreateConnection(string connectionString)
		{
			var connection = new SqlConnection(connectionString);
			connection.Open();

			return connection;
		}
	}
}