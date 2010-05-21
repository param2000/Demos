namespace CreationConsole.FactoryMethod.InjectFactory
{
	using System;

	public abstract class KoolAid
	{
		public abstract string Color { get; }

		public abstract void Prepare();
		public abstract void Sweeten();
	}

	public class CherryKoolAid :
		KoolAid
	{
		public override string Color
		{
			get { return "red"; }
		}

		public override void Prepare()
		{
			Console.WriteLine("Preparing cherry kool aid");
		}

		public override void Sweeten()
		{
			Console.WriteLine("Adding 2 cups of sugar");
		}
	}

	public class GrapeKoolAid :
		KoolAid
	{
		public override string Color
		{
			get { return "red"; }
		}

		public override void Prepare()
		{
			Console.WriteLine("Preparing grape kool aid");
		}

		public override void Sweeten()
		{
			Console.WriteLine("Adding 2 cups of sugar");
		}
	}

	public class KoolAidFactory
	{
		public KoolAid Create(string flavor)
		{
			switch (flavor)
			{
				case "cherry":
					return new CherryKoolAid();

				case "grape":
					return new GrapeKoolAid();

				default:
					Console.WriteLine("Unknown flavor: " + flavor);
					return null;
			}
		}

		public class BeverageStand
		{
			private readonly KoolAidFactory _factory;

			public BeverageStand(KoolAidFactory factory)
			{
				_factory = factory;
			}

			public KoolAid OrderKoolAid(string flavor)
			{
				KoolAid koolAid = _factory.Create(flavor);

				koolAid.Prepare();
				koolAid.Sweeten();

				return koolAid;
			}
		}

		public class BeverageWebSite
		{
			private readonly KoolAidFactory _factory;

			public BeverageWebSite(KoolAidFactory factory)
			{
				_factory = factory;
			}

			public KoolAid OrderKoolAid(string flavor)
			{
				KoolAid koolAid = _factory.Create(flavor);

				koolAid.Prepare();
				koolAid.Sweeten();

				return koolAid;
			}
		}

		public class Test
		{
			public void Create_using_new()
			{
				var koolAidFactory = new KoolAidFactory();
				var beverageStand = new BeverageStand(koolAidFactory);

				KoolAid koolAid = beverageStand.OrderKoolAid("cherry");

				Console.WriteLine("Color: {0}", koolAid.Color);
			}
		}
	}
}