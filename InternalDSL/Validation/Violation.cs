namespace Validation
{
	public interface Violation
	{
		string Message { get; }
		string Key { get; }
	}

	public interface Violation<T> :
		Violation
	{
	}
}