using System;
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
		private static class Cache<T> where T : class
		{
			public static readonly Func<Arguments<T>, Arguments<T>> Verifier = VerifierFactory.Create<T, object>(
				t => !t.IsValueType,
				(valueVar, _) => Expr.ReferenceEqual(valueVar, Expr.Constant(null)),
				(n, _) => new ArgumentNullException(n));
		}

		/// <summary>
		/// Checks that arguments are not null.
		/// Throws <see cref="ArgumentNullException" /> if check is failed.
		/// </summary>
		/// <typeparam name="T">Anonymous object type.</typeparam>
		/// <param name="args">Arguments holder.</param>
		/// <returns>Arguments holder used for subsequent checks.</returns>
		public static Arguments<T> NotNull<T>(this Arguments<T> args) where T : class
		{
			return Cache<T>.Verifier(args);
		}
	}

	#endregion

	#region NotEmpty()

	/// <summary>
	/// <see cref="NotEmpty{T}" /> method plugin.
	/// </summary>
	public static class NotEmptyPlugin
	{
		private static class Cache<T> where T : class
		{
			public static readonly Func<Arguments<T>, Arguments<T>> Verifier = VerifierFactory.Create<T, object>(
				TypeUtil.HasLengthProperty,
				(valueVar, _) =>
				{
					var lengthExpr = Expr.Property(valueVar, valueVar.Type.HasProperty("Length") ? "Length" : "Count");
					Expr body = Expr.Equal(lengthExpr, Expr.Constant(0));
					return valueVar.Type.IsValueType
						? body
						: Expr.AndAlso(Expr.ReferenceNotEqual(valueVar, Expr.Constant(null)), body);
				},
				(n, _) => new ArgumentException(ErrorMessages.NotEmpty, n));
		}

		/// <summary>
		/// Checks that arguments are not empty strings/collections.
		/// Throws <see cref="ArgumentException" /> if check is failed.
		/// </summary>
		/// <typeparam name="T">Anonymous object type.</typeparam>
		/// <param name="args">Arguments holder.</param>
		/// <returns>Arguments holder used for subsequent checks.</returns>
		public static Arguments<T> NotEmpty<T>(this Arguments<T> args) where T : class
		{
			return Cache<T>.Verifier(args);
		}
	}

	#endregion

	#region NotDefault()

	/// <summary>
	/// <see cref="NotDefault{T}" /> method plugin.
	/// </summary>
	public static class NotDefaultPlugin
	{
		private static class Cache<T> where T : class
		{
			public static readonly Func<Arguments<T>, Arguments<T>> Verifier = VerifierFactory.Create<T, object>(
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
		public static Arguments<T> NotDefault<T>(this Arguments<T> args) where T : class
		{
			return Cache<T>.Verifier(args);
		}
	}

	#endregion

	#region NotNullOrEmpty()

	/// <summary>
	/// <see cref="NotNullOrEmpty{T}" /> method plugin.
	/// </summary>
	public static class NotNullOrEmptyPlugin
	{
		/// <summary>
		/// Checks that arguments are not null or empty.
		/// Throws <see cref="ArgumentNullException" /> or <see cref="ArgumentException" /> if check is failed.
		/// </summary>
		/// <typeparam name="T">Anonymous object type.</typeparam>
		/// <param name="args">Arguments holder.</param>
		/// <returns>Arguments holder used for subsequent checks.</returns>
		public static Arguments<T> NotNullOrEmpty<T>(this Arguments<T> args) where T : class
		{
			return args.NotNull().NotEmpty();
		}
	}

	#endregion
}
