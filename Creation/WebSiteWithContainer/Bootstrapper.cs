namespace WebSiteWithContainer
{
	using StructureMap;
	using WebSite.Core.Data;

	public class Bootstrapper
	{
		public void Bootstrap()
		{
			ObjectFactory.Initialize(x =>
				{
					x.For<ISqlConnectionFactory>()
						.Singleton()
						.Use<SqlConnectionFactory>();

					x.For<IConnectionContext>()
						.HttpContextScoped()
						.Use<ConnectionContext>()
						.WithCtorArg("connectionStringName").EqualTo("Default");

					x.SetAllProperties(p => p.OfType<IConnectionContext>());
				});
		}
	}
}