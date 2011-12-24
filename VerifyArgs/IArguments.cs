namespace VerifyArgs
{
	/// <summary>
	/// Holds arguments to verify.
	/// </summary>
	/// <typeparam name="THolder">Anonymous object type.</typeparam>
	public interface IArguments<out THolder> where THolder : class
	{
		/// <summary>
		/// Gets anonymous object which contains arguments to verify.
		/// </summary>
		THolder Holder { get; }
	}
}
