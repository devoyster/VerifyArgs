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
		/// <param name="holder">Anonymous object which contains arguments to verify.</param>
		/// <returns>Arguments holder used for subsequent checks.</returns>
		public static IArguments<T> Args<T>(T holder) where T : class
		{
			return new ArgumentsImpl<T>(holder);
		}

		#region Plugins interface duplicate

		#region CommonPlugins

		/// <summary>
		/// Checks that arguments are not null.
		/// </summary>
		/// <typeparam name="T">Anonymous object type.</typeparam>
		/// <param name="holder">Anonymous object which contains arguments to verify.</param>
		/// <returns>Arguments holder used for subsequent checks.</returns>
		public static IArguments<T> NotNull<T>(T holder) where T : class
		{
			return Args(holder).NotNull();
		}

		/// <summary>
		/// Checks that arguments are not empty strings/collections.
		/// </summary>
		/// <typeparam name="T">Anonymous object type.</typeparam>
		/// <param name="holder">Anonymous object which contains arguments to verify.</param>
		/// <returns>Arguments holder used for subsequent checks.</returns>
		public static IArguments<T> NotEmpty<T>(T holder) where T : class
		{
			return Args(holder).NotEmpty();
		}

		/// <summary>
		/// Checks that arguments are not null or empty.
		/// </summary>
		/// <typeparam name="T">Anonymous object type.</typeparam>
		/// <param name="holder">Anonymous object which contains arguments to verify.</param>
		/// <returns>Arguments holder used for subsequent checks.</returns>
		public static IArguments<T> NotNullOrEmpty<T>(T holder) where T : class
		{
			return Args(holder).NotNullOrEmpty();
		}

		#endregion

		#endregion
	}
}
