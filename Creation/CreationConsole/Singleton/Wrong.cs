namespace CreationConsole.Singleton
{
	using System;

	public static class Wrong
	{
		static Wrong()
		{
			Console.WriteLine("Static initializer being invoked");
		}

		public static void MyMethod()
		{
			Console.WriteLine("My Method called");
		}
	}

	public partial class Test
	{
		public void Should_call_one_instance()
		{
			Console.WriteLine("Calling method");

			Wrong.MyMethod();
		}
	}
}