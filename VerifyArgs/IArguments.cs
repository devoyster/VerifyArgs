namespace VerifyArgs
{
	/// <summary>
	/// Holds arguments to verify.
	/// </summary>
	public interface IArguments
	{
		/// <summary>
		/// Gets anonymous object which contains arguments to verify.
		/// </summary>
		object Holder { get; }
	}
}
