namespace CreationConsole.FactoryMethod.ExtractStaticToClass
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
	public class LemonLimeKoolAid :
		KoolAid
	{
		public override string Color
		{
			get { return "yellow-ish"; }
		}

		public override void Prepare()
		{
			Console.WriteLine("Preparing lemon-lime kool aid");
		}

		public override void Sweeten()
		{
			Console.WriteLine("Adding 3 cups of sugar");
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

				case "lemon-lime":
					return new LemonLimeKoolAid();

				default:
					Console.WriteLine("Unknown flavor: " + flavor);
					return null;
			}
		}

		public class BeverageStand
		{
			public KoolAid OrderKoolAid(string flavor)
			{
				var factory = new KoolAidFactory();
				KoolAid koolAid = factory.Create(flavor);

				koolAid.Prepare();
				koolAid.Sweeten();

				return koolAid;
			}
		}

		public class BeverageWebSite
		{
			public KoolAid OrderKoolAid(string flavor)
			{
				var factory = new KoolAidFactory();
				KoolAid koolAid = factory.Create(flavor);

				koolAid.Prepare();
				koolAid.Sweeten();

				return koolAid;
			}
		}

		public class Test
		{
			public void Create_using_new()
			{
				var beverageStand = new BeverageStand();

				KoolAid koolAid = beverageStand.OrderKoolAid("lemon-lime");

				Console.WriteLine("Color: {0}", koolAid.Color);
			}
		}
	}
}