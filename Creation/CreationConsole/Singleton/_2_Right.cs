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

		private static Func<DateTime> _now = () => DateTime.Now;

		public DateTime Now
		{
			get
			{
				return _now();
			}
		}

		public void ReplaceDateTimeWith(Func<DateTime> nower)
		{
			_now = nower;
		}

		public void SetInstance(Right right)
		{
			lock(_lock)
				_instance = right;
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

			Console.WriteLine("The time is : " + Right.Instance.Now);

			Right.Instance.ReplaceDateTimeWith(() => new DateTime(2010,03,01));

			Console.WriteLine("The time is now: " + Right.Instance.Now);
		}
	}
}