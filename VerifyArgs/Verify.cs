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
		public static IArguments<T> Args<T>(T holder) where T : class
		{
			return new ArgumentsImpl<T>(holder);
		}

		#region Plugins interface duplicate for plugin methods without additional parameters

		#region CommonPlugins

		/// <summary>
		/// Checks that arguments are not null.
		/// Throws <see cref="ArgumentNullException" /> if check is failed.
		/// </summary>
		/// <typeparam name="T">Anonymous object type.</typeparam>
		/// <param name="holder">Anonymous object which contains arguments to verify. Example: new { param1, param2 }</param>
		/// <returns>Arguments holder used for subsequent checks.</returns>
		public static IArguments<T> NotNull<T>(T holder) where T : class
		{
			return Args(holder).NotNull();
		}

		/// <summary>
		/// Checks that arguments are not empty strings/collections.
		/// Throws <see cref="ArgumentException" /> if check is failed.
		/// </summary>
		/// <typeparam name="T">Anonymous object type.</typeparam>
		/// <param name="holder">Anonymous object which contains arguments to verify. Example: new { param1, param2 }</param>
		/// <returns>Arguments holder used for subsequent checks.</returns>
		public static IArguments<T> NotEmpty<T>(T holder) where T : class
		{
			return Args(holder).NotEmpty();
		}

		/// <summary>
		/// Checks that value-type arguments are not having default values.
		/// Throws <see cref="ArgumentException" /> if check is failed.
		/// </summary>
		/// <typeparam name="T">Anonymous object type.</typeparam>
		/// <param name="holder">Anonymous object which contains arguments to verify. Example: new { param1, param2 }</param>
		/// <returns>Arguments holder used for subsequent checks.</returns>
		public static IArguments<T> NotDefault<T>(T holder) where T : class
		{
			return Args(holder).NotDefault();
		}

		/// <summary>
		/// Checks that arguments are not null or empty.
		/// Throws <see cref="ArgumentNullException" /> or <see cref="ArgumentException" /> if check is failed.
		/// </summary>
		/// <typeparam name="T">Anonymous object type.</typeparam>
		/// <param name="holder">Anonymous object which contains arguments to verify. Example: new { param1, param2 }</param>
		/// <returns>Arguments holder used for subsequent checks.</returns>
		public static IArguments<T> NotNullOrEmpty<T>(T holder) where T : class
		{
			return Args(holder).NotNullOrEmpty();
		}

		#endregion

		#region NumericPlugins

		/// <summary>
		/// Checks that numeric arguments are positive (greater than zero).
		/// Throws <see cref="ArgumentOutOfRangeException" /> if check is failed.
		/// </summary>
		/// <typeparam name="T">Anonymous object type.</typeparam>
		/// <param name="holder">Anonymous object which contains arguments to verify. Example: new { param1, param2 }</param>
		/// <returns>Arguments holder used for subsequent checks.</returns>
		public static IArguments<T> Positive<T>(T holder) where T : class
		{
			return Args(holder).Positive();
		}

		/// <summary>
		/// Checks that numeric arguments are not negative (greater than or equal zero).
		/// Throws <see cref="ArgumentOutOfRangeException" /> if check is failed.
		/// </summary>
		/// <typeparam name="T">Anonymous object type.</typeparam>
		/// <param name="holder">Anonymous object which contains arguments to verify. Example: new { param1, param2 }</param>
		/// <returns>Arguments holder used for subsequent checks.</returns>
		public static IArguments<T> NotNegative<T>(T holder) where T : class
		{
			return Args(holder).NotNegative();
		}

		/// <summary>
		/// Checks that numeric arguments are negative (less than zero).
		/// Throws <see cref="ArgumentOutOfRangeException" /> if check is failed.
		/// </summary>
		/// <typeparam name="T">Anonymous object type.</typeparam>
		/// <param name="holder">Anonymous object which contains arguments to verify. Example: new { param1, param2 }</param>
		/// <returns>Arguments holder used for subsequent checks.</returns>
		public static IArguments<T> Negative<T>(T holder) where T : class
		{
			return Args(holder).Negative();
		}

		/// <summary>
		/// Checks that numeric arguments are not positive (less than or equal zero).
		/// Throws <see cref="ArgumentOutOfRangeException" /> if check is failed.
		/// </summary>
		/// <typeparam name="T">Anonymous object type.</typeparam>
		/// <param name="holder">Anonymous object which contains arguments to verify. Example: new { param1, param2 }</param>
		/// <returns>Arguments holder used for subsequent checks.</returns>
		public static IArguments<T> NotPositive<T>(T holder) where T : class
		{
			return Args(holder).NotPositive();
		}

		#endregion

		#endregion
	}
}
