namespace CreationConsole.FactoryMethod.AbstractFactory
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

	public class SugarFreeCherryKoolAid :
		KoolAid
	{
		public override string Color
		{
			get { return "red"; }
		}

		public override void Prepare()
		{
			Console.WriteLine("Preparing sugar free cherry kool aid");
		}

		public override void Sweeten()
		{
			Console.WriteLine("Adding 0.5ml of artifical sweetener");
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

	public abstract class KoolAidFactory
	{
		public abstract KoolAid Create(string flavor);
	}

	public class SweetenedKoolAidFactory :
		KoolAidFactory
	{
		public override KoolAid Create(string flavor)
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
	}

	public class SugarFreeKoolAidFactory :
		KoolAidFactory
	{
		public override KoolAid Create(string flavor)
		{
			switch (flavor)
			{
				case "cherry":
					return new SugarFreeCherryKoolAid();

				default:
					Console.WriteLine("Unknown flavor: " + flavor);
					return null;
			}
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
			var koolAidFactory = new SugarFreeKoolAidFactory();
			var beverageStand = new BeverageStand(koolAidFactory);

			KoolAid koolAid = beverageStand.OrderKoolAid("cherry");

			Console.WriteLine("Color: {0}", koolAid.Color);
		}
	}
}