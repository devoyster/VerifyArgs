﻿using System;
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
		private static class Check<T> where T : class
		{
			public static readonly Action<T, decimal> Action = NumericPluginsUtil.Generate<T>(
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
		public static IArguments<T> GreaterThan<T>(this IArguments<T> args, decimal min) where T : class
		{
			Check<T>.Action(args.Holder, min);
			return args;
		}
	}

	#endregion

	#region GreaterThanOrEqual()

	/// <summary>
	/// <see cref="GreaterThanOrEqual{T}" /> method plugin.
	/// </summary>
	public static class GreaterThanOrEqualPlugin
	{
		private static class Check<T> where T : class
		{
			public static readonly Action<T, decimal> Action = NumericPluginsUtil.Generate<T>(
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
		public static IArguments<T> GreaterThanOrEqual<T>(this IArguments<T> args, decimal min) where T : class
		{
			Check<T>.Action(args.Holder, min);
			return args;
		}
	}

	#endregion

	#region LessThan()

	/// <summary>
	/// <see cref="LessThan{T}" /> method plugin.
	/// </summary>
	public static class LessThanPlugin
	{
		private static class Check<T> where T : class
		{
			public static readonly Action<T, decimal> Action = NumericPluginsUtil.Generate<T>(
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
		public static IArguments<T> LessThan<T>(this IArguments<T> args, decimal max) where T : class
		{
			Check<T>.Action(args.Holder, max);
			return args;
		}
	}

	#endregion

	#region LessThanOrEqual()

	/// <summary>
	/// <see cref="LessThanOrEqual{T}" /> method plugin.
	/// </summary>
	public static class LessThanOrEqualPlugin
	{
		private static class Check<T> where T : class
		{
			public static readonly Action<T, decimal> Action = NumericPluginsUtil.Generate<T>(
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
		public static IArguments<T> LessThanOrEqual<T>(this IArguments<T> args, decimal max) where T : class
		{
			Check<T>.Action(args.Holder, max);
			return args;
		}
	}

	#endregion

	#region InRange()

	/// <summary>
	/// <see cref="InRange{T}" /> method plugin.
	/// </summary>
	public static class InRangePlugin
	{
		private static class Check<T> where T : class
		{
			public static readonly Action<T, decimal, decimal> Action = NumericPluginsUtil.Generate<T>(
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
		public static IArguments<T> InRange<T>(this IArguments<T> args, decimal min, decimal max) where T : class
		{
			Check<T>.Action(args.Holder, min, max);
			return args;
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
		public static IArguments<T> Positive<T>(this IArguments<T> args) where T : class
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
		public static IArguments<T> NotNegative<T>(this IArguments<T> args) where T : class
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
		public static IArguments<T> Negative<T>(this IArguments<T> args) where T : class
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
		public static IArguments<T> NotPositive<T>(this IArguments<T> args) where T : class
		{
			return args.LessThanOrEqual(0);
		}
	}

	#endregion

	internal static class NumericPluginsUtil
	{
		public static Action<T, decimal> Generate<T>(Expression<Func<decimal, decimal, bool>> checkExpr, string errorMessage)
		{
			return ActionFactory.Generate<T, decimal, decimal>(
				TypeUtil.IsNumeric,
				checkExpr,
				(n, x, param) => new ArgumentOutOfRangeException(n, x, string.Format(errorMessage, param)));
		}

		public static Action<T, decimal, decimal> Generate<T>(Expression<Func<decimal, decimal, decimal, bool>> checkExpr, string errorMessage)
		{
			return ActionFactory.Generate<T, decimal, decimal, decimal>(
				TypeUtil.IsNumeric,
				checkExpr,
				(n, x, p1, p2) => new ArgumentOutOfRangeException(n, x, string.Format(errorMessage, p1, p2)));
		}
	}
}
