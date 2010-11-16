namespace CreationConsole.FactoryMethod.Original
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
			get { return "purple"; }
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

	public class BeverageStand
	{
		public KoolAid OrderKoolAid(string flavor)
		{
			KoolAid koolAid;
			switch (flavor)
			{
				case "cherry":
					koolAid = new CherryKoolAid();
					break;

				case "grape":
					koolAid = new GrapeKoolAid();
					break;

				default:
					Console.WriteLine("Unknown flavor: " + flavor);
					return null;
			}

			koolAid.Prepare();
			koolAid.Sweeten();

			return koolAid;
		}
	}

	// what happens we start taking online orders as well?
	public class BeverageWebSite
	{
		public KoolAid OrderKoolAid(string flavor)
		{
			KoolAid koolAid;
			switch (flavor)
			{
				case "cherry":
					koolAid = new CherryKoolAid();
					break;

				case "grape":
					koolAid = new GrapeKoolAid();
					break;

				default:
					Console.WriteLine("Unknown flavor: " + flavor);
					return null;
			}

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

			KoolAid koolAid = beverageStand.OrderKoolAid("cherry");

			Console.WriteLine("Color: {0}", koolAid.Color);
		}
	}
}