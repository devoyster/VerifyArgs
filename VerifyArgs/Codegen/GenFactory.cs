using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using VerifyArgs.Util;

using Expr = System.Linq.Expressions.Expression;

namespace VerifyArgs.Codegen
{
	/// <summary>
	/// Creates action generators for argument checks.
	/// </summary>
	public static partial class GenFactory
	{
		/// <summary>
		/// Returns object check actions generator - it generates action by object type.
		/// Generator is thread-safe.
		/// </summary>
		/// <typeparam name="TFake">Fake object type, use any type convenient for <paramref name="checkExpr" /> and <paramref cref="createExceptionExpr" />.</typeparam>
		/// <param name="propertyFilter">Object public properties filter; can be null to generate code for all the properties.</param>
		/// <param name="checkExpr">Property value check lambda expression; if returns true then check is failed.</param>
		/// <param name="createExceptionExpr">New exception creation expression used when check is failed.</param>
		/// <returns>Check actions generator.</returns>
		public static Func<Type, Action<object>> CreateGenerator<TFake>(
			Func<Type, bool> propertyFilter,
			Expression<Func<TFake, bool>> checkExpr,
			Expression<Func<string, TFake, Exception>> createExceptionExpr)
		{
			return CreateGenerator<Action<object>>(propertyFilter, checkExpr, createExceptionExpr);
		}

		/// <summary>
		/// Returns object check actions generator - it generates action by object type.
		/// Generator is thread-safe.
		/// </summary>
		/// <typeparam name="TFake">Fake object type, use any type convenient for <paramref name="checkExpr" /> and <paramref cref="createExceptionExpr" />.</typeparam>
		/// <typeparam name="T">Additional non-constant parameter type.</typeparam>
		/// <param name="propertyFilter">Object public properties filter; can be null to generate code for all the properties.</param>
		/// <param name="checkExpr">Property value check lambda expression; if returns true then check is failed.</param>
		/// <param name="createExceptionExpr">New exception creation expression used when check is failed.</param>
		/// <returns>Check actions generator.</returns>
		public static Func<Type, Action<object, T>> CreateGenerator<TFake, T>(
			Func<Type, bool> propertyFilter,
			Expression<Func<TFake, T, bool>> checkExpr,
			Expression<Func<string, TFake, T, Exception>> createExceptionExpr)
		{
			return CreateGenerator<Action<object, T>>(propertyFilter, checkExpr, createExceptionExpr, typeof(T));
		}

		/// <summary>
		/// Returns object check actions generator - it generates action by object type.
		/// Generator is thread-safe.
		/// </summary>
		/// <typeparam name="TAction">Action type.</typeparam>
		/// <param name="propertyFilter">Object public properties filter; can be null to generate code for all the properties.</param>
		/// <param name="checkExpr">Property value check lambda expression; if returns true then check is failed.</param>
		/// <param name="createExceptionExpr">New exception creation expression used when check is failed.</param>
		/// <param name="additionalParamTypes">Types of additional non-constant parameters to supply into <typeparamref name="TAction" />.</param>
		/// <returns>Check actions generator.</returns>
		private static Func<Type, TAction> CreateGenerator<TAction>(
			Func<Type, bool> propertyFilter,
			LambdaExpression checkExpr,
			LambdaExpression createExceptionExpr,
			params Type[] additionalParamTypes) where TAction : class
		{
			var cache = new Dictionary<Type, TAction>();
			var rwLock = new ReaderWriterLockSlim(LockRecursionPolicy.NoRecursion);

			return
				type =>
				{
					// Try to obtain generated action from cache
					using (rwLock.ReadLock())
					{
						TAction result;
						if (cache.TryGetValue(type, out result)) return result;
					}

					// Generate new action and cache it
					var generated = Generate<TAction>(type, propertyFilter, checkExpr, createExceptionExpr, additionalParamTypes);
					using (rwLock.WriteLock())
					{
						// Ensure that it's not in cache already
						TAction result;
						if (cache.TryGetValue(type, out result)) return result;

						cache.Add(type, generated);
					}
					return generated;
				};
		}

		/// <summary>
		/// Generates action which checks object public properties.
		/// </summary>
		/// <typeparam name="TAction">Action type.</typeparam>
		/// <param name="type">Checked object type.</param>
		/// <param name="propertyFilter">Object public properties filter; can be null to generate code for all the properties.</param>
		/// <param name="checkExpr">Property value check lambda expression; if returns true then check id failed.</param>
		/// <param name="createExceptionExpr">New exception creation expression used when check is failed.</param>
		/// <param name="additionalParamTypes">Types of additional non-constant parameters to supply into <see cref="TAction" />.</param>
		/// <returns>Object check action.</returns>
		private static TAction Generate<TAction>(
		   Type type,
		   Func<Type, bool> propertyFilter,
		   LambdaExpression checkExpr,
		   LambdaExpression createExceptionExpr,
		   params Type[] additionalParamTypes) where TAction : class
		{
			// Prepare lambda action parameters - first is object, others are additionalParamTypes
			var objectParam = Expr.Parameter(typeof(object));
			var objectVar = Expr.Variable(type);
			var additionalParams = additionalParamTypes.Select(Expr.Parameter).ToList();

			// Take checkExpr lambda, extract first parameter from it and replace additional parameters in body
			Func<LambdaExpression, Expression> replaceAdditionalParams =
				expr =>
					expr
						.Parameters
						.Skip(expr.Parameters.Count - additionalParams.Count)
						.Zip(additionalParams, (from, to) => new { from, to })
						.Aggregate(expr.Body, (body, x) => body.Replace(x.from, x.to));

			var checkObjectParam = checkExpr.Parameters[0];
			var checkBody = replaceAdditionalParams(checkExpr);

			// Similar for createExceptionExpr lambda
			var exceptionNameParam = createExceptionExpr.Parameters[0];
			var exceptionObjectParam = createExceptionExpr.Parameters[1];
			var exceptionBody = replaceAdditionalParams(createExceptionExpr);

			// Obtain type public properties to check
			propertyFilter = propertyFilter ?? (_ => true);
			var properties = type.GetProperties().Where(pi => propertyFilter(pi.PropertyType));

			// Generate "if (checkExpr) then throw createExceptionExpr;" for each of the properties
			IEnumerable<Expression> propertyChecks = properties.Select(
				pi =>
				{
					var valueVar = Expr.Variable(pi.PropertyType);
					return Expr.Block(
						new[] { valueVar },
						Expr.Assign(valueVar, Expr.Property(objectVar, pi)),
						Expr.IfThen(
							checkBody.Replace(checkObjectParam, valueVar),
							Expr.Throw(
								exceptionBody
									.Replace(exceptionNameParam, Expr.Constant(pi.Name))
									.Replace(exceptionObjectParam, valueVar))));
				});

			// Pull it all together, execute checks only if supplied object is not null
			var lambda = Expr.Lambda<TAction>(
				Expr.Block(
					new[] { objectVar },
					propertyChecks.Prepend(Expr.Assign(objectVar, Expr.Convert(objectParam, type)))),
				additionalParams.Prepend(objectParam));
			return lambda.Compile();
		}
	}
}
