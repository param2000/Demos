namespace Validation.Impl
{
	public class ViolationImpl<T> :
		Violation<T>
	{
		public ViolationImpl(string key, string message)
		{
			Key = key;
			Message = message;
		}

		public ViolationImpl(string message)
		{
			Key = "";
			Message = message;
		}

		public string Key { get; private set; }
		public string Message { get; private set; }

		public override string ToString()
		{
			return string.IsNullOrEmpty(Key) ? Message : Key + " " + Message;
		}
	}
}