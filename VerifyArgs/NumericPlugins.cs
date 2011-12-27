using System;
using System.Linq.Expressions;
using VerifyArgs.Codegen;
using VerifyArgs.Util;

namespace VerifyArgs
{
	#region GreaterThan()

	/// <summary>
	/// <see cref="GreaterThan{T}" /> method plugin.
	/// </summary>
	public static class GreaterThanPlugin
	{
		private static class Cache<T> where T : class
		{
			public static readonly Func<Arguments<T>, decimal, Arguments<T>> Verifier = NumericPluginsUtil.Create<T>(
				(x, min) => x <= min,
				ErrorMessages.GreaterThan);
		}

		/// <summary>
		/// Checks that numeric arguments are greather than <paramref name="min" />.
		/// Throws <see cref="ArgumentOutOfRangeException" /> if check is failed.
		/// </summary>
		/// <typeparam name="T">Anonymous object type.</typeparam>
		/// <param name="args">Arguments holder.</param>
		/// <param name="min">Minimal argument value.</param>
		/// <returns>Arguments holder used for subsequent checks.</returns>
		public static Arguments<T> GreaterThan<T>(this Arguments<T> args, decimal min) where T : class
		{
			return Cache<T>.Verifier(args, min);
		}
	}

	#endregion

	#region GreaterThanOrEqual()

	/// <summary>
	/// <see cref="GreaterThanOrEqual{T}" /> method plugin.
	/// </summary>
	public static class GreaterThanOrEqualPlugin
	{
		private static class Cache<T> where T : class
		{
			public static readonly Func<Arguments<T>, decimal, Arguments<T>> Verifier = NumericPluginsUtil.Create<T>(
				(x, min) => x < min,
				ErrorMessages.GreaterThanOrEqual);
		}

		/// <summary>
		/// Checks that numeric arguments are greather than or equal <paramref name="min" />.
		/// Throws <see cref="ArgumentOutOfRangeException" /> if check is failed.
		/// </summary>
		/// <typeparam name="T">Anonymous object type.</typeparam>
		/// <param name="args">Arguments holder.</param>
		/// <param name="min">Minimal argument value.</param>
		/// <returns>Arguments holder used for subsequent checks.</returns>
		public static Arguments<T> GreaterThanOrEqual<T>(this Arguments<T> args, decimal min) where T : class
		{
			return Cache<T>.Verifier(args, min);
		}
	}

	#endregion

	#region LessThan()

	/// <summary>
	/// <see cref="LessThan{T}" /> method plugin.
	/// </summary>
	public static class LessThanPlugin
	{
		private static class Cache<T> where T : class
		{
			public static readonly Func<Arguments<T>, decimal, Arguments<T>> Verifier = NumericPluginsUtil.Create<T>(
				(x, max) => x >= max,
				ErrorMessages.LessThan);
		}

		/// <summary>
		/// Checks that numeric arguments are less than <paramref name="max" />.
		/// Throws <see cref="ArgumentOutOfRangeException" /> if check is failed.
		/// </summary>
		/// <typeparam name="T">Anonymous object type.</typeparam>
		/// <param name="args">Arguments holder.</param>
		/// <param name="max">Maximal argument value.</param>
		/// <returns>Arguments holder used for subsequent checks.</returns>
		public static Arguments<T> LessThan<T>(this Arguments<T> args, decimal max) where T : class
		{
			return Cache<T>.Verifier(args, max);
		}
	}

	#endregion

	#region LessThanOrEqual()

	/// <summary>
	/// <see cref="LessThanOrEqual{T}" /> method plugin.
	/// </summary>
	public static class LessThanOrEqualPlugin
	{
		private static class Cache<T> where T : class
		{
			public static readonly Func<Arguments<T>, decimal, Arguments<T>> Verifier = NumericPluginsUtil.Create<T>(
				(x, max) => x > max,
				ErrorMessages.LessThanOrEqual);
		}

		/// <summary>
		/// Checks that numeric arguments are less than or equal <paramref name="max" />.
		/// Throws <see cref="ArgumentOutOfRangeException" /> if check is failed.
		/// </summary>
		/// <typeparam name="T">Anonymous object type.</typeparam>
		/// <param name="args">Arguments holder.</param>
		/// <param name="max">Maximal argument value.</param>
		/// <returns>Arguments holder used for subsequent checks.</returns>
		public static Arguments<T> LessThanOrEqual<T>(this Arguments<T> args, decimal max) where T : class
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
		/// <summary>
		/// Checks that numeric arguments are positive (greater than zero).
		/// Throws <see cref="ArgumentOutOfRangeException" /> if check is failed.
		/// </summary>
		/// <typeparam name="T">Anonymous object type.</typeparam>
		/// <param name="args">Arguments holder.</param>
		/// <returns>Arguments holder used for subsequent checks.</returns>
		public static Arguments<T> Positive<T>(this Arguments<T> args) where T : class
		{
			return args.GreaterThan(0);
		}
	}

	#endregion

	#region NotNegative()

	/// <summary>
	/// <see cref="NotNegative{T}" /> method plugin.
	/// </summary>
	public static class NotNegativePlugin
	{
		/// <summary>
		/// Checks that numeric arguments are not negative (greater than or equal zero).
		/// Throws <see cref="ArgumentOutOfRangeException" /> if check is failed.
		/// </summary>
		/// <typeparam name="T">Anonymous object type.</typeparam>
		/// <param name="args">Arguments holder.</param>
		/// <returns>Arguments holder used for subsequent checks.</returns>
		public static Arguments<T> NotNegative<T>(this Arguments<T> args) where T : class
		{
			return args.GreaterThanOrEqual(0);
		}
	}

	#endregion

	#region Negative()

	/// <summary>
	/// <see cref="Negative{T}" /> method plugin.
	/// </summary>
	public static class NegativePlugin
	{
		/// <summary>
		/// Checks that numeric arguments are negative (less than zero).
		/// Throws <see cref="ArgumentOutOfRangeException" /> if check is failed.
		/// </summary>
		/// <typeparam name="T">Anonymous object type.</typeparam>
		/// <param name="args">Arguments holder.</param>
		/// <returns>Arguments holder used for subsequent checks.</returns>
		public static Arguments<T> Negative<T>(this Arguments<T> args) where T : class
		{
			return args.LessThan(0);
		}
	}

	#endregion

	#region NotPositive()

	/// <summary>
	/// <see cref="NotPositive{T}" /> method plugin.
	/// </summary>
	public static class NotPositivePlugin
	{
		/// <summary>
		/// Checks that numeric arguments are not positive (less than or equal zero).
		/// Throws <see cref="ArgumentOutOfRangeException" /> if check is failed.
		/// </summary>
		/// <typeparam name="T">Anonymous object type.</typeparam>
		/// <param name="args">Arguments holder.</param>
		/// <returns>Arguments holder used for subsequent checks.</returns>
		public static Arguments<T> NotPositive<T>(this Arguments<T> args) where T : class
		{
			return args.LessThanOrEqual(0);
		}
	}

	#endregion

	internal static class NumericPluginsUtil
	{
		public static Func<Arguments<T>, decimal, Arguments<T>> Create<T>(Expression<Func<decimal, decimal, bool>> checkExpr, string errorMessage) where T : class
		{
			return VerifierFactory.Create<T, decimal, decimal>(
				TypeUtil.IsNumeric,
				checkExpr,
				(n, x, param) => new ArgumentOutOfRangeException(n, x, string.Format(errorMessage, param)));
		}

		public static Func<Arguments<T>, decimal, decimal, Arguments<T>> Create<T>(Expression<Func<decimal, decimal, decimal, bool>> checkExpr, string errorMessage) where T : class
		{
			return VerifierFactory.Create<T, decimal, decimal, decimal>(
				TypeUtil.IsNumeric,
				checkExpr,
				(n, x, p1, p2) => new ArgumentOutOfRangeException(n, x, string.Format(errorMessage, p1, p2)));
		}
	}
}
