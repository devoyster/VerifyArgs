using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using VerifyArgs.Util;

using Expr = System.Linq.Expressions.Expression;

namespace VerifyArgs.Codegen
{
	/// <summary>
	/// Creates action generators for argument checks.
	/// </summary>
	public static partial class ActionFactory
	{
		/// <summary>
		/// Generates action which checks object public properties.
		/// </summary>
		/// <typeparam name="THolder">Anonymous object type.</typeparam>
		/// <typeparam name="TFake">Fake object type, use any type convenient for <paramref name="checkExpr" /> and <paramref cref="createExceptionExpr" />.</typeparam>
		/// <param name="propertyFilter">Object public properties filter; can be null to generate code for all the properties.</param>
		/// <param name="checkExpr">Property value check lambda expression; if returns true then check id failed.</param>
		/// <param name="createExceptionExpr">New exception creation expression used when check is failed.</param>
		/// <returns>Object check action.</returns>
		public static Action<THolder> Generate<THolder, TFake>(
			Func<Type, bool> propertyFilter,
			Expression<Func<TFake, bool>> checkExpr,
			Expression<Func<string, TFake, Exception>> createExceptionExpr)
		{
			return Generate<Action<THolder>>(propertyFilter, checkExpr, createExceptionExpr);
		}

		/// <summary>
		/// Generates action which checks object public properties.
		/// </summary>
		/// <typeparam name="THolder">Anonymous object type.</typeparam>
		/// <typeparam name="TFake">Fake object type, use any type convenient for <paramref name="checkExpr" /> and <paramref cref="createExceptionExpr" />.</typeparam>
		/// <typeparam name="T">Additional non-constant parameter type.</typeparam>
		/// <param name="propertyFilter">Object public properties filter; can be null to generate code for all the properties.</param>
		/// <param name="checkExpr">Property value check lambda expression; if returns true then check id failed.</param>
		/// <param name="createExceptionExpr">New exception creation expression used when check is failed.</param>
		/// <returns>Object check action.</returns>
		public static Action<THolder, T> Generate<THolder, TFake, T>(
			Func<Type, bool> propertyFilter,
			Expression<Func<TFake, T, bool>> checkExpr,
			Expression<Func<string, TFake, T, Exception>> createExceptionExpr)
		{
			return Generate<Action<THolder, T>>(propertyFilter, checkExpr, createExceptionExpr);
		}

		/// <summary>
		/// Generates action which checks object public properties.
		/// </summary>
		/// <typeparam name="TAction">Action type.</typeparam>
		/// <param name="propertyFilter">Object public properties filter; can be null to generate code for all the properties.</param>
		/// <param name="checkExpr">Property value check lambda expression; if returns true then check id failed.</param>
		/// <param name="createExceptionExpr">New exception creation expression used when check is failed.</param>
		/// <returns>Object check action.</returns>
		private static TAction Generate<TAction>(
		   Func<Type, bool> propertyFilter,
		   LambdaExpression checkExpr,
		   LambdaExpression createExceptionExpr) where TAction : class
		{
			Type type = typeof(TAction).GetGenericArguments()[0];

			// Prepare lambda action parameters - first is object, others are additionalParamTypes
			var objectParam = Expr.Parameter(type);
			var additionalParams = typeof(TAction).GetGenericArguments().Skip(1).Select(Expr.Parameter).ToList();

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
			var propertyChecks = properties
				.Select(
					pi =>
					{
						var valueVar = Expr.Variable(pi.PropertyType);
						return Expr.Block(
							new[] { valueVar },
							Expr.Assign(valueVar, Expr.Property(objectParam, pi)),
							Expr.IfThen(
								checkBody.Replace(checkObjectParam, valueVar),
								Expr.Throw(
									exceptionBody
										.Replace(exceptionNameParam, Expr.Constant(pi.Name))
										.Replace(exceptionObjectParam, valueVar))));
					})
				.ToList();

			Expression lambdaBody;
			if (propertyChecks.Any())
			{
				lambdaBody = Expr.IfThen(
					Expr.ReferenceNotEqual(objectParam, Expr.Constant(null)),
					propertyChecks.Count == 1 ? propertyChecks[0] : Expr.Block(propertyChecks));
			}
			else
			{
				lambdaBody = Expr.Default(typeof(void));
			}

			// Pull it all together, execute checks only if supplied object is not null
			var lambda = Expr.Lambda<TAction>(
				lambdaBody,
				new[] { objectParam }.Concat(additionalParams));
			return lambda.Compile();
		}
	}
}
