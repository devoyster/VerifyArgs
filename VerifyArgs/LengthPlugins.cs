﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using VerifyArgs.Codegen;
using VerifyArgs.Util;

using Expr = System.Linq.Expressions.Expression;

namespace VerifyArgs
{
	#region LengthGreaterThan()

	/// <summary>
	/// <see cref="LengthGreaterThan{T}" /> method plugin.
	/// </summary>
	public static class LengthGreaterThanPlugin
	{
		private static class Cache<T> where T : class
		{
			public static readonly Func<Arguments<T>, int, Arguments<T>> Verifier = LengthPluginsUtil.Create<T>(
				(x, minLength) => x <= minLength,
				ErrorMessages.LengthGreaterThan);
		}

		/// <summary>
		/// Checks that string/collection arguments length is greather than <paramref name="minLength" />.
		/// Throws <see cref="ArgumentException" /> if check is failed.
		/// </summary>
		/// <typeparam name="T">Anonymous object type.</typeparam>
		/// <param name="args">Arguments holder.</param>
		/// <param name="minLength">Minimal argument length.</param>
		/// <returns>Arguments holder used for subsequent checks.</returns>
		public static Arguments<T> LengthGreaterThan<T>(this Arguments<T> args, int minLength) where T : class
		{
			return Cache<T>.Verifier(args, minLength);
		}
	}

	#endregion

	#region LengthGreaterThanOrEqual()

	/// <summary>
	/// <see cref="LengthGreaterThanOrEqual{T}" /> method plugin.
	/// </summary>
	public static class LengthGreaterThanOrEqualPlugin
	{
		private static class Cache<T> where T : class
		{
			public static readonly Func<Arguments<T>, int, Arguments<T>> Verifier = LengthPluginsUtil.Create<T>(
				(x, minLength) => x < minLength,
				ErrorMessages.GreaterThanOrEqual);
		}

		/// <summary>
		/// Checks that string/collection arguments length is greather than or equal <paramref name="minLength" />.
		/// Throws <see cref="ArgumentException" /> if check is failed.
		/// </summary>
		/// <typeparam name="T">Anonymous object type.</typeparam>
		/// <param name="args">Arguments holder.</param>
		/// <param name="minLength">Minimal argument length.</param>
		/// <returns>Arguments holder used for subsequent checks.</returns>
		public static Arguments<T> LengthGreaterThanOrEqual<T>(this Arguments<T> args, int minLength) where T : class
		{
			return Cache<T>.Verifier(args, minLength);
		}
	}

	#endregion

	#region LengthLessThan()

	/// <summary>
	/// <see cref="LengthLessThan{T}" /> method plugin.
	/// </summary>
	public static class LengthLessThanPlugin
	{
		private static class Cache<T> where T : class
		{
			public static readonly Func<Arguments<T>, int, Arguments<T>> Verifier = LengthPluginsUtil.Create<T>(
				(x, maxLength) => x >= maxLength,
				ErrorMessages.LengthLessThan);
		}

		/// <summary>
		/// Checks that string/collection arguments length is less than <paramref name="maxLength" />.
		/// Throws <see cref="ArgumentException" /> if check is failed.
		/// </summary>
		/// <typeparam name="T">Anonymous object type.</typeparam>
		/// <param name="args">Arguments holder.</param>
		/// <param name="maxLength">Maximal argument length.</param>
		/// <returns>Arguments holder used for subsequent checks.</returns>
		public static Arguments<T> LengthLessThan<T>(this Arguments<T> args, int maxLength) where T : class
		{
			return Cache<T>.Verifier(args, maxLength);
		}
	}

	#endregion

	#region LengthLessThanOrEqual()

	/// <summary>
	/// <see cref="LengthLessThanOrEqual{T}" /> method plugin.
	/// </summary>
	public static class LengthLessThanOrEqualPlugin
	{
		private static class Cache<T> where T : class
		{
			public static readonly Func<Arguments<T>, int, Arguments<T>> Verifier = LengthPluginsUtil.Create<T>(
				(x, maxLength) => x > maxLength,
				ErrorMessages.LengthLessThanOrEqual);
		}

		/// <summary>
		/// Checks that string/collection arguments length is less than or equal <paramref name="maxLength" />.
		/// Throws <see cref="ArgumentException" /> if check is failed.
		/// </summary>
		/// <typeparam name="T">Anonymous object type.</typeparam>
		/// <param name="args">Arguments holder.</param>
		/// <param name="maxLength">Maximal argument length.</param>
		/// <returns>Arguments holder used for subsequent checks.</returns>
		public static Arguments<T> LengthLessThanOrEqual<T>(this Arguments<T> args, int maxLength) where T : class
		{
			return Cache<T>.Verifier(args, maxLength);
		}
	}

	#endregion

	#region LengthEquals()

	/// <summary>
	/// <see cref="LengthEqual{T}" /> method plugin.
	/// </summary>
	public static class LengthEqualPlugin
	{
		private static class Cache<T> where T : class
		{
			public static readonly Func<Arguments<T>, int, Arguments<T>> Verifier = LengthPluginsUtil.Create<T>(
				(x, length) => x != length,
				ErrorMessages.LengthEquals);
		}

		/// <summary>
		/// Checks that string/collection arguments length equals <paramref name="length" />.
		/// Throws <see cref="ArgumentException" /> if check is failed.
		/// </summary>
		/// <typeparam name="T">Anonymous object type.</typeparam>
		/// <param name="args">Arguments holder.</param>
		/// <param name="length">Expected argument length.</param>
		/// <returns>Arguments holder used for subsequent checks.</returns>
		public static Arguments<T> LengthEqual<T>(this Arguments<T> args, int length) where T : class
		{
			return Cache<T>.Verifier(args, length);
		}
	}

	#endregion

	#region LengthInRange()

	/// <summary>
	/// <see cref="LengthInRange{T}" /> method plugin.
	/// </summary>
	public static class LengthInRangePlugin
	{
		private static class Cache<T> where T : class
		{
			public static readonly Func<Arguments<T>, int, int, Arguments<T>> Verifier = LengthPluginsUtil.Create<T>(
				(x, minLength, maxLength) => x < minLength || x > maxLength,
				ErrorMessages.LengthInRange);
		}

		/// <summary>
		/// Checks that string/collection arguments length is in given range (inclusive).
		/// Throws <see cref="ArgumentException" /> if check is failed.
		/// </summary>
		/// <typeparam name="T">Anonymous object type.</typeparam>
		/// <param name="args">Arguments holder.</param>
		/// <param name="minLength">Minimal argument length.</param>
		/// <param name="maxLength">Maximal argument length.</param>
		/// <returns>Arguments holder used for subsequent checks.</returns>
		public static Arguments<T> LengthInRange<T>(this Arguments<T> args, int minLength, int maxLength) where T : class
		{
			return Cache<T>.Verifier(args, minLength, maxLength);
		}
	}

	#endregion

	internal static class LengthPluginsUtil
	{
		public static Func<Arguments<T>, int, Arguments<T>> Create<T>(Expression<Func<int, int, bool>> checkExpr, string errorMessage) where T : class
		{
			return VerifierFactory.Create<T, object, int>(
				TypeUtil.HasLengthProperty,
				CreateCheckExprFunc(checkExpr),
				(n, _, param) => new ArgumentException(string.Format(errorMessage, param), n));
		}

		public static Func<Arguments<T>, int, int, Arguments<T>> Create<T>(Expression<Func<int, int, int, bool>> checkExpr, string errorMessage) where T : class
		{
			return VerifierFactory.Create<T, object, int, int>(
				TypeUtil.HasLengthProperty,
				CreateCheckExprFunc(checkExpr),
				(n, _, p1, p2) => new ArgumentException(string.Format(errorMessage, p1, p2), n));
		}

		private static Func<Expression, IList<ParameterExpression>, Expr> CreateCheckExprFunc(LambdaExpression checkExpr)
		{
			return
				(valueVar, additionalParams) =>
				{
					// Prepare Length/Count expression
					var lengthExpr = Expr.Property(valueVar, valueVar.Type.HasProperty("Length") ? "Length" : "Count");

					// Use it in checkExpr
					var body = checkExpr.ReplaceParams(additionalParams).Replace(checkExpr.Parameters[0], lengthExpr);

					// Maybe add null check
					if (!valueVar.Type.IsValueType)
					{
						body = Expr.AndAlso(Expr.ReferenceNotEqual(valueVar, Expr.Constant(null)), body);
					}

					return body;
				};
		}
	}
}
