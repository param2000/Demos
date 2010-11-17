namespace Validation
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Runtime.Serialization;

	[Serializable]
	public class ViolationException :
		ValidationException
	{
		public ViolationException()
		{
			Violations = new Violation[] {};
		}

		public ViolationException(IEnumerable<Violation> violations)
		{
			Violations = violations.ToArray();
		}

		public ViolationException(IEnumerable<Violation> violations, string message)
			: base(message)
		{
			Violations = violations.ToArray();
		}

		public ViolationException(string message, Exception innerException)
			: base(message, innerException)
		{
			Violations = new Violation[] {};
		}

		protected ViolationException(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
			Violations = new Violation[] {};
		}

		public IEnumerable<Violation> Violations { get; private set; }
	}
}