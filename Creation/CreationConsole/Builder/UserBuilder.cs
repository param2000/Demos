namespace CreationConsole.Builder
{
	using System;

	public abstract class UserBuilder
	{
		private UserLevel _level;
		private string _username;

		public virtual UserBuilder Username(string name)
		{
			_username = name;
			return this;
		}

		public virtual UserBuilder Level(UserLevel level)
		{
			_level = level;
			return this;
		}

		public virtual User Create()
		{
			return new User(_username, _level);
		}
	}

	public class AdminUserBuilder :
		UserBuilder
	{
		public override UserBuilder Level(UserLevel level)
		{
			if (level != UserLevel.Normal)
				throw new InvalidOperationException("Not authorized to create administrator");

			return base.Level(level);
		}
	}

	public class SuperAdminUserBuilder :
		UserBuilder
	{
		public override UserBuilder Level(UserLevel level)
		{
			if (level != UserLevel.Normal && level != UserLevel.Admin)
				throw new InvalidOperationException("Not authorized to create administrator");

			return base.Level(level);
		}
	}

	public enum UserLevel
	{
		Normal,
		Admin,
		SuperAdmin
	}

	public class User
	{
		public User(string username, UserLevel level)
		{
			Username = username;
			Level = level;
		}

		public string Username { get; private set; }
		public UserLevel Level { get; private set; }
	}


	public class Test
	{
		public void Should_only_be_allowed_to_create_normal_users()
		{
			User user = new AdminUserBuilder()
				.Username("regular.joe")
				.Level(UserLevel.Normal)
				.Create();

			Console.WriteLine("User " + user.Username + " created as " + user.Level);
		}

		public void Should_only_be_allowed_to_create_admin_users()
		{
			User user = new SuperAdminUserBuilder()
				.Username("super.man")
				.Level(UserLevel.Admin)
				.Create();

			Console.WriteLine("User " + user.Username + " created as " + user.Level);
		}
	}
}