using System;

namespace VerifyArgs.Util
{
	/// <summary>
	/// Straightforward replacement for <see cref="Verify" /> for code which can't use <see cref="Verify" />
	/// because this will cause stack overflow.
	/// </summary>
	internal static class VerifyUtil
	{
		/// <summary>
		/// Checks argument for null.
		/// </summary>
		/// <param name="arg">Argument to check.</param>
		/// <param name="name">Argument name.</param>
		public static void NotNull(object arg, string name)
		{
			if (arg == null)
			{
				throw new ArgumentNullException(name);
			}
		}
	}
}
