namespace CreationConsole.Singleton
{
	using System;
	using StructureMap;

	public class ConfigurationValues
	{
		public ConfigurationValues()
		{
			ConnectionString = "Not Configured";
		}

		public string ConnectionString { get; set; }
	}

	public class Connection
	{
		public Connection(ConfigurationValues configuration)
		{
			ConnectionString = configuration.ConnectionString;
		}

		public string ConnectionString { get; private set; }
	}

	public partial class Test
	{
		public void Should_get_the_same_instance_from_the_container()
		{
			IContainer container = new Container(c =>
				{
					// let's give it a lifestyle
					c.For<ConfigurationValues>().Singleton();
				});

			// let's set it
			container.GetInstance<ConfigurationValues>().ConnectionString = "MySQLServer";

			var connection = container.GetInstance<Connection>();
			Console.WriteLine("Connection String: " + connection.ConnectionString);

			// eject the singleton and try again
//			container.EjectAllInstancesOf<ConfigurationValues>();
//
//			connection = container.GetInstance<Connection>();
//			Console.WriteLine("Connection String: " + connection.ConnectionString);
		}
	}
}