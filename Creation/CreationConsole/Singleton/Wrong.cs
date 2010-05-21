namespace CreationConsole.Singleton
{
	public static class Wrong
	{
		public static void MyMethod()
		{
		}
	}

	public partial class Test
	{
		public void Should_call_one_instance()
		{
			Wrong.MyMethod();
		}
	}
}