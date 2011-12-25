using System;
using System.Collections;
using VerifyArgs.Codegen;
using VerifyArgs.Util;

using Expr = System.Linq.Expressions.Expression;

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
		/// Throws <see cref="ArgumentNullException" /> if check is failed.
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
				x => x != null && !x.GetEnumerator().MoveNext(),
				(n, _) => new ArgumentException(ErrorMessages.NotEmpty, n));
		}

		/// <summary>
		/// Checks that arguments are not empty strings/collections.
		/// Throws <see cref="ArgumentException" /> if check is failed.
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

	#region NotDefault()

	/// <summary>
	/// <see cref="NotDefault{T}" /> method plugin.
	/// </summary>
	static public class NotDefaultPlugin
	{
		private static class Check<T> where T : class
		{
			public static readonly Action<T> Action = ActionFactory.Generate<T, object>(
				t => t.IsValueType,
				(valueVar, _) => Expr.Call(valueVar, "Equals", null, Expr.Default(valueVar.Type)),
				(n, _) => new ArgumentException(ErrorMessages.NotDefault, n));
		}

		/// <summary>
		/// Checks that value-type arguments are not having default values.
		/// Throws <see cref="ArgumentException" /> if check is failed.
		/// </summary>
		/// <typeparam name="T">Anonymous object type.</typeparam>
		/// <param name="args">Arguments holder.</param>
		/// <returns>Arguments holder used for subsequent checks.</returns>
		static public IArguments<T> NotDefault<T>(this IArguments<T> args) where T : class
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
		/// Throws <see cref="ArgumentNullException" /> or <see cref="ArgumentException" /> if check is failed.
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
