using System;

namespace VerifyArgs
{
	/// <summary>
	/// Helpers for argument checks.
	/// </summary>
	public static class Verify
	{
		/// <summary>
		/// Provides interface for argument checks.
		/// </summary>
		/// <typeparam name="T">Anonymous object type.</typeparam>
		/// <param name="holder">Anonymous object which contains arguments to verify. Example: new { param1, param2 }</param>
		/// <returns>Arguments holder used for subsequent checks.</returns>
		public static Arguments<T> Args<T>(T holder) where T : class
		{
			return new Arguments<T>(holder);
		}
	}
}
