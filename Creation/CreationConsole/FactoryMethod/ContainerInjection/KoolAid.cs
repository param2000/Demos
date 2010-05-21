namespace CreationConsole.FactoryMethod.ContainerInjection
{
	using System;
	using StructureMap;

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

	public abstract class KoolAidMaker
	{
		public abstract KoolAid MakeKoolAid(string flavor);
	}

	public class LowCostKoolAidMaker :
		KoolAidMaker
	{
		private readonly KoolAidFactory _factory;

		public LowCostKoolAidMaker(KoolAidFactory factory)
		{
			_factory = factory;
		}

		public override KoolAid MakeKoolAid(string flavor)
		{
			KoolAid koolAid = _factory.Create(flavor);

			koolAid.Prepare();
			koolAid.Sweeten();

			return koolAid;
		}

	}

	public class BeverageStand
	{
		private readonly KoolAidMaker _maker;

		public BeverageStand(KoolAidMaker maker)
		{
			_maker = maker;
		}

		public KoolAid OrderKoolAid(string flavor)
		{
			return _maker.MakeKoolAid(flavor);
		}
	}

	public class BeverageWebSite
	{
		private readonly KoolAidMaker _maker;

		public BeverageWebSite(KoolAidMaker maker)
		{
			_maker = maker;
		}

		public KoolAid OrderKoolAid(string flavor)
		{
			return _maker.MakeKoolAid(flavor);
		}
	}

	public class Test
	{
		public void Create_using_new()
		{
			IContainer container = new Container(c =>
				{
					c.For<KoolAidFactory>()
						.Use<SweetenedKoolAidFactory>();
					c.For<KoolAidMaker>()
						.Use<LowCostKoolAidMaker>();
				});

			var beverageStand = container.GetInstance<BeverageStand>();

			KoolAid koolAid = beverageStand.OrderKoolAid("cherry");

			Console.WriteLine("Color: {0}", koolAid.Color);
		}
	}
}