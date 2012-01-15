using System;
using System.Linq.Expressions;
using VerifyArgs.Codegen;
using VerifyArgs.Util;

using Expr = System.Linq.Expressions.Expression;

namespace VerifyArgs
{
	#region MinValue()

	/// <summary>
	/// <see cref="MinValue{T}" /> method plugin.
	/// </summary>
	public static class MinValuePlugin
	{
		private static class Cache<T> where T : class
		{
			public static readonly Func<Arguments<T>, decimal, Arguments<T>> Verifier = NumericPluginsUtil.Create<T>(
				(x, min) => x < min,
				ErrorMessages.MinValue);
		}

		/// <summary>
		/// Checks that numeric arguments are greather than or equal <paramref name="min" />.
		/// Throws <see cref="ArgumentOutOfRangeException" /> if check is failed.
		/// </summary>
		/// <typeparam name="T">Anonymous object type.</typeparam>
		/// <param name="args">Arguments holder.</param>
		/// <param name="min">Minimal argument value.</param>
		/// <returns>Arguments holder used for subsequent checks.</returns>
		public static Arguments<T> MinValue<T>(this Arguments<T> args, decimal min) where T : class
		{
			return Cache<T>.Verifier(args, min);
		}
	}

	#endregion

	#region MaxValue()

	/// <summary>
	/// <see cref="MaxValue{T}" /> method plugin.
	/// </summary>
	public static class MaxValuePlugin
	{
		private static class Cache<T> where T : class
		{
			public static readonly Func<Arguments<T>, decimal, Arguments<T>> Verifier = NumericPluginsUtil.Create<T>(
				(x, max) => x > max,
				ErrorMessages.MaxValue);
		}

		/// <summary>
		/// Checks that numeric arguments are less than or equal <paramref name="max" />.
		/// Throws <see cref="ArgumentOutOfRangeException" /> if check is failed.
		/// </summary>
		/// <typeparam name="T">Anonymous object type.</typeparam>
		/// <param name="args">Arguments holder.</param>
		/// <param name="max">Maximal argument value.</param>
		/// <returns>Arguments holder used for subsequent checks.</returns>
		public static Arguments<T> MaxValue<T>(this Arguments<T> args, decimal max) where T : class
		{
			return Cache<T>.Verifier(args, max);
		}
	}

	#endregion

	#region InRange()

	/// <summary>
	/// <see cref="InRange{T}" /> method plugin.
	/// </summary>
	public static class InRangePlugin
	{
		private static class Cache<T> where T : class
		{
			public static readonly Func<Arguments<T>, decimal, decimal, Arguments<T>> Verifier = NumericPluginsUtil.Create<T>(
				(x, min, max) => x < min || x > max,
				ErrorMessages.InRange);
		}

		/// <summary>
		/// Checks that numeric arguments are in given range (inclusive).
		/// Throws <see cref="ArgumentOutOfRangeException" /> if check is failed.
		/// </summary>
		/// <typeparam name="T">Anonymous object type.</typeparam>
		/// <param name="args">Arguments holder.</param>
		/// <param name="min">Minimal argument value.</param>
		/// <param name="max">Maximal argument value.</param>
		/// <returns>Arguments holder used for subsequent checks.</returns>
		public static Arguments<T> InRange<T>(this Arguments<T> args, decimal min, decimal max) where T : class
		{
			return Cache<T>.Verifier(args, min, max);
		}
	}

	#endregion

	#region Positive()

	/// <summary>
	/// <see cref="Positive{T}" /> method plugin.
	/// </summary>
	public static class PositivePlugin
	{
		private static class Cache<T> where T : class
		{
			public static readonly Func<Arguments<T>, Arguments<T>> Verifier = NumericPluginsUtil.Create<T>(
				Expr.LessThanOrEqual,
				ErrorMessages.Positive);
		}

		/// <summary>
		/// Checks that numeric arguments are positive (greater than zero).
		/// Throws <see cref="ArgumentOutOfRangeException" /> if check is failed.
		/// </summary>
		/// <typeparam name="T">Anonymous object type.</typeparam>
		/// <param name="args">Arguments holder.</param>
		/// <returns>Arguments holder used for subsequent checks.</returns>
		public static Arguments<T> Positive<T>(this Arguments<T> args) where T : class
		{
			return Cache<T>.Verifier(args);
		}
	}

	#endregion

	#region NotNegative()

	/// <summary>
	/// <see cref="NotNegative{T}" /> method plugin.
	/// </summary>
	public static class NotNegativePlugin
	{
		private static class Cache<T> where T : class
		{
			public static readonly Func<Arguments<T>, Arguments<T>> Verifier = NumericPluginsUtil.Create<T>(
				Expr.LessThan,
				ErrorMessages.NotNegative);
		}

		/// <summary>
		/// Checks that numeric arguments are not negative (greater than or equal zero).
		/// Throws <see cref="ArgumentOutOfRangeException" /> if check is failed.
		/// </summary>
		/// <typeparam name="T">Anonymous object type.</typeparam>
		/// <param name="args">Arguments holder.</param>
		/// <returns>Arguments holder used for subsequent checks.</returns>
		public static Arguments<T> NotNegative<T>(this Arguments<T> args) where T : class
		{
			return Cache<T>.Verifier(args);
		}
	}

	#endregion

	#region Negative()

	/// <summary>
	/// <see cref="Negative{T}" /> method plugin.
	/// </summary>
	public static class NegativePlugin
	{
		private static class Cache<T> where T : class
		{
			public static readonly Func<Arguments<T>, Arguments<T>> Verifier = NumericPluginsUtil.Create<T>(
				Expr.GreaterThanOrEqual,
				ErrorMessages.Negative);
		}

		/// <summary>
		/// Checks that numeric arguments are negative (less than zero).
		/// Throws <see cref="ArgumentOutOfRangeException" /> if check is failed.
		/// </summary>
		/// <typeparam name="T">Anonymous object type.</typeparam>
		/// <param name="args">Arguments holder.</param>
		/// <returns>Arguments holder used for subsequent checks.</returns>
		public static Arguments<T> Negative<T>(this Arguments<T> args) where T : class
		{
			return Cache<T>.Verifier(args);
		}
	}

	#endregion

	#region NotPositive()

	/// <summary>
	/// <see cref="NotPositive{T}" /> method plugin.
	/// </summary>
	public static class NotPositivePlugin
	{
		private static class Cache<T> where T : class
		{
			public static readonly Func<Arguments<T>, Arguments<T>> Verifier = NumericPluginsUtil.Create<T>(
				Expr.GreaterThan,
				ErrorMessages.NotPositive);
		}

		/// <summary>
		/// Checks that numeric arguments are not positive (less than or equal zero).
		/// Throws <see cref="ArgumentOutOfRangeException" /> if check is failed.
		/// </summary>
		/// <typeparam name="T">Anonymous object type.</typeparam>
		/// <param name="args">Arguments holder.</param>
		/// <returns>Arguments holder used for subsequent checks.</returns>
		public static Arguments<T> NotPositive<T>(this Arguments<T> args) where T : class
		{
			return Cache<T>.Verifier(args);
		}
	}

	#endregion

	internal static class NumericPluginsUtil
	{
		public static Func<Arguments<T>, Arguments<T>> Create<T>(Func<Expr, Expr, BinaryExpression> compareWithZeroExprFunc, string errorMessage) where T : class
		{
			return VerifierFactory.Create<T, decimal>(
				TypeUtil.IsNumeric,
				(valueVar, _) => compareWithZeroExprFunc(valueVar, Expr.Constant(Convert.ChangeType(0, valueVar.Type, null))),
				(n, x) =>
#if NETFW
					new ArgumentOutOfRangeException(n, x, errorMessage)
#else
					new ArgumentOutOfRangeException(n, errorMessage)
#endif
				);
		}

		public static Func<Arguments<T>, decimal, Arguments<T>> Create<T>(Expression<Func<decimal, decimal, bool>> checkExpr, string errorMessage) where T : class
		{
			return VerifierFactory.Create<T, decimal, decimal>(
				TypeUtil.IsNumeric,
				checkExpr,
				(n, x, param) =>
#if NETFW
					new ArgumentOutOfRangeException(n, x, string.Format(errorMessage, param))
#else
					new ArgumentOutOfRangeException(n, string.Format(errorMessage, param))
#endif
				);
		}

		public static Func<Arguments<T>, decimal, decimal, Arguments<T>> Create<T>(Expression<Func<decimal, decimal, decimal, bool>> checkExpr, string errorMessage) where T : class
		{
			return VerifierFactory.Create<T, decimal, decimal, decimal>(
				TypeUtil.IsNumeric,
				checkExpr,
				(n, x, p1, p2) =>
#if NETFW
					new ArgumentOutOfRangeException(n, x, string.Format(errorMessage, p1, p2))
#else
					new ArgumentOutOfRangeException(n, string.Format(errorMessage, p1, p2))
#endif
				);
		}
	}
}
