using VerifyArgs.Util;

namespace VerifyArgs
{
	/// <summary>
	/// Holds arguments to verify.
	/// </summary>
	/// <typeparam name="THolder">Anonymous object type.</typeparam>
	public struct Arguments<THolder> where THolder : class
	{
		/// <summary>
		/// Anonymous object which contains arguments to verify.
		/// </summary>
		public readonly THolder Holder;

		/// <summary>
		/// Creates new <see cref="Arguments{THolder}" /> instance.
		/// </summary>
		/// <param name="holder">Anonymous object which contains arguments to verify. Example: new { param1, param2 }</param>
		public Arguments(THolder holder)
		{
			VerifyUtil.NotNull(holder, "holder");
			Holder = holder;
		}
	}
}
