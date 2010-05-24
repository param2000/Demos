namespace WebSiteWithContainer
{
	using System;
	using System.Web;
	using StructureMap.Pipeline;

	public class Global : HttpApplication
	{
		protected void Application_Start(object sender, EventArgs e)
		{
			new Bootstrapper().Bootstrap();
		}

		protected void Session_Start(object sender, EventArgs e)
		{
		}

		protected void Application_BeginRequest(object sender, EventArgs e)
		{
		}

		protected void Application_AuthenticateRequest(object sender, EventArgs e)
		{
		}

		protected void Application_EndRequest(object sender, EventArgs e)
		{
			HttpContextLifecycle.DisposeAndClearAll();
		}

		protected void Application_Error(object sender, EventArgs e)
		{
		}

		protected void Session_End(object sender, EventArgs e)
		{
		}

		protected void Application_End(object sender, EventArgs e)
		{
		}
	}
}