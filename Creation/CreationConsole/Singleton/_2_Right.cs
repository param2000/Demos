namespace CreationConsole.Singleton
{
	using System;

	public class Right
	{
		private static readonly object _lock = new object();
		private static Right _instance;

		protected Right()
		{
			Console.WriteLine("Constructing Right");
		}

		public static Right Instance
		{
			get
			{
				if (_instance == null)
				{
					lock (_lock)
					{
						if (_instance == null)
							_instance = new Right();
					}
				}

				return _instance;
			}
		}

		public void MyMethod()
		{
			Console.WriteLine("MyMethod is running");
		}
	}


	public partial class Test
	{
		public void Should_access_a_single_instance_of_the_class()
		{
			Console.WriteLine("Calling method");
			Right.Instance.MyMethod();

			Console.WriteLine("Calling method again");
			Right.Instance.MyMethod();
		}
	}
}