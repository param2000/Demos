namespace CreationConsole.Singleton
{
	using System;

	public class Singleton<T>
		where T : class, new()
	{
		private static readonly object _lock = new object();
		private static T _instance;

		protected Singleton()
		{
		}

		public static T Instance
		{
			get
			{
				if (_instance == null)
				{
					lock (_lock)
					{
						if (_instance == null)
							_instance = new T();
					}
				}

				return _instance;
			}
		}

		public static void Use(T instance)
		{
			_instance = instance;
		}

		public void MyMethod()
		{
			Console.WriteLine("MyMethod is running");
		}
	}

	public class Subject
	{
		public Subject()
		{
			Console.WriteLine("Creating instance of Subject");
		}

		public int Value { get; set; }
	}


	public partial class Test
	{
		public void Should_use_the_generic_singleton()
		{
			Singleton<Subject>.Instance.Value = 27;

			Console.WriteLine("Value = " + Singleton<Subject>.Instance.Value);
		}

		public void Should_use_my_prebuilt_instance()
		{
			Subject subject = new Subject();
			subject.Value = 42;
			Singleton<Subject>.Use(subject);

			Console.WriteLine("Value = " + Singleton<Subject>.Instance.Value);
		}
	}
}