using System;
using System.Collections;
using VerifyArgs.Codegen;

namespace VerifyArgs
{
	#region NotNull()

	/// <summary>
	/// <see cref="NotNull{T}" /> method plugin.
	/// </summary>
	public static class NotNullPlugin
	{
		private static class Check<T> where T : class
		{
			public static readonly Action<T> Action = ActionFactory.Generate<T, object>(
				t => !t.IsValueType,
				x => x == null,
				(n, _) => new ArgumentNullException(n));
		}

		/// <summary>
		/// Checks that arguments are not null.
		/// </summary>
		/// <typeparam name="T">Anonymous object type.</typeparam>
		/// <param name="args">Arguments holder.</param>
		/// <returns>Arguments holder used for subsequent checks.</returns>
		static public IArguments<T> NotNull<T>(this IArguments<T> args) where T : class
		{
			Check<T>.Action(args.Holder);
			return args;
		}
	}

	#endregion

	#region NotEmpty()

	/// <summary>
	/// <see cref="NotEmpty{T}" /> method plugin.
	/// </summary>
	static public class NotEmptyPlugin
	{
		private static class Check<T> where T : class
		{
			public static readonly Action<T> Action = ActionFactory.Generate<T, IEnumerable>(
				t => typeof(IEnumerable).IsAssignableFrom(t),
				x => x != null && !((IEnumerable)x).GetEnumerator().MoveNext(),
				(n, _) => new ArgumentException("Value can't be empty.", n));
		}

		/// <summary>
		/// Checks that arguments are not empty strings/collections.
		/// </summary>
		/// <typeparam name="T">Anonymous object type.</typeparam>
		/// <param name="args">Arguments holder.</param>
		/// <returns>Arguments holder used for subsequent checks.</returns>
		static public IArguments<T> NotEmpty<T>(this IArguments<T> args) where T : class
		{
			Check<T>.Action(args.Holder);
			return args;
		}
	}

	#endregion

	#region NotNullOrEmpty()

	/// <summary>
	/// <see cref="NotNullOrEmpty{T}" /> method plugin.
	/// </summary>
	static public class NotNullOrEmptyPlugin
	{
		/// <summary>
		/// Checks that arguments are not null or empty.
		/// </summary>
		/// <typeparam name="T">Anonymous object type.</typeparam>
		/// <param name="args">Arguments holder.</param>
		/// <returns>Arguments holder used for subsequent checks.</returns>
		static public IArguments<T> NotNullOrEmpty<T>(this IArguments<T> args) where T : class
		{
			return args.NotNull().NotEmpty();
		}
	}

	#endregion
}
