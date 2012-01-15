using System;
using System.Runtime.Serialization;

namespace VerifyArgs
{
	/// <summary>
	/// Thrown when object supplied into <see cref="Verify.Args{T}" /> call is not of anonymous type.
	/// </summary>
#if NETFW
	[Serializable]
#endif
	public class VerifyArgsException : Exception
	{
		/// <summary>
		/// Creates new <see cref="VerifyArgsException" /> instance.
		/// </summary>
		/// <param name="message">Error message.</param>
		public VerifyArgsException(string message) : base(message)
		{
		}

#if NETFW
		/// <summary>
		/// Creates new <see cref="VerifyArgsException" /> instance from serialization stream.
		/// </summary>
		/// <param name="info">Serialization info.</param>
		/// <param name="context">Streaming context.</param>
		protected VerifyArgsException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
#endif
	}
}
