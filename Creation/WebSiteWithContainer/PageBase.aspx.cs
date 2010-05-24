namespace WebSiteWithContainer
{
	using System.Web.UI;
	using StructureMap;

	public class PageBase<T> :
		Page
		where T : class
	{
		public PageBase()
		{
			ObjectFactory.BuildUp(this as T);
		}
	}
}