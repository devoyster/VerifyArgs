namespace VerifyArgs
{
	/// <summary>
	/// Holds arguments to verify.
	/// </summary>
	/// <typeparam name="T">Anonymous object type.</typeparam>
	public struct Arguments<T> where T : class
	{
		/// <summary>
		/// Anonymous object which contains arguments to verify.
		/// </summary>
		public readonly T Holder;

		/// <summary>
		/// Creates new <see cref="Arguments{THolder}" /> instance.
		/// </summary>
		/// <param name="holder">Anonymous object which contains arguments to verify. Example: new { param1, param2 }</param>
		public Arguments(T holder)
		{
			Holder = holder;
		}
	}
}
