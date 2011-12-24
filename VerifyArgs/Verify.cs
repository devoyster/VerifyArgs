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
		/// <param name="holder">Anonymous object which contains arguments to verify.</param>
		/// <returns>Arguments holder used for subsequent checks.</returns>
		public static IArguments Args(object holder)
		{
			return new ArgumentsImpl(holder);
		}

		#region Plugins interface duplicate

		public static void NotNull(object holder)
		{
			Args(holder).NotNull();
		}

		public static void NotEmpty(object holder)
		{
			Args(holder).NotEmpty();
		}

		public static void NotNullOrEmpty(object holder)
		{
			Args(holder).NotNullOrEmpty();
		}

		public static void GreaterThan(object holder, decimal min)
		{
			Args(holder).GreaterThan(min);
		}

		#endregion
	}
}
