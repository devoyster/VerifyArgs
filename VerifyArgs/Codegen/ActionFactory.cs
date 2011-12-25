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
		#region Generic wrappers

		/// <summary>
		/// Generates action which checks object public properties.
		/// </summary>
		/// <typeparam name="THolder">Anonymous object type.</typeparam>
		/// <typeparam name="TArg">Common arguments supertype used in <paramref name="checkExpr" /> and <paramref name="createExceptionExpr" />.</typeparam>
		/// <param name="propertyFilter">Object public properties filter; can be null to generate code for all the properties.</param>
		/// <param name="checkExpr">Property value check lambda expression; if returns true then check is failed.</param>
		/// <param name="createExceptionExpr">New exception creation expression used when check is failed.</param>
		/// <returns>Object check action.</returns>
		public static Action<THolder> Generate<THolder, TArg>(
			Func<Type, bool> propertyFilter,
			Expression<Func<TArg, bool>> checkExpr,
			Expression<Func<string, TArg, Exception>> createExceptionExpr)
		{
			return Generate<Action<THolder>>(propertyFilter, checkExpr, createExceptionExpr);
		}

		/// <summary>
		/// Generates action which checks object public properties.
		/// </summary>
		/// <typeparam name="THolder">Anonymous object type.</typeparam>
		/// <typeparam name="TArg">Common arguments supertype used in <paramref name="createExceptionExpr" />.</typeparam>
		/// <param name="propertyFilter">Object public properties filter; can be null to generate code for all the properties.</param>
		/// <param name="checkExprFunc">Function which generates property value check expression (if returns true then check is failed).
		/// Function obtains variable which holds property value and additional parameters.</param>
		/// <param name="createExceptionExpr">New exception creation expression used when check is failed.</param>
		/// <returns>Object check action.</returns>
		public static Action<THolder> Generate<THolder, TArg>(
			Func<Type, bool> propertyFilter,
			Func<ParameterExpression, IList<ParameterExpression>, Expr> checkExprFunc,
			Expression<Func<string, TArg, Exception>> createExceptionExpr)
		{
			return Generate<Action<THolder>>(propertyFilter, checkExprFunc, createExceptionExpr);
		}

		/// <summary>
		/// Generates action which checks object public properties.
		/// </summary>
		/// <typeparam name="THolder">Anonymous object type.</typeparam>
		/// <typeparam name="TArg">Common arguments supertype used in <paramref name="checkExpr" /> and <paramref name="createExceptionExpr" />.</typeparam>
		/// <typeparam name="T">Additional non-constant parameter type.</typeparam>
		/// <param name="propertyFilter">Object public properties filter; can be null to generate code for all the properties.</param>
		/// <param name="checkExpr">Property value check lambda expression; if returns true then check is failed.</param>
		/// <param name="createExceptionExpr">New exception creation expression used when check is failed.</param>
		/// <returns>Object check action.</returns>
		public static Action<THolder, T> Generate<THolder, TArg, T>(
			Func<Type, bool> propertyFilter,
			Expression<Func<TArg, T, bool>> checkExpr,
			Expression<Func<string, TArg, T, Exception>> createExceptionExpr)
		{
			return Generate<Action<THolder, T>>(propertyFilter, checkExpr, createExceptionExpr);
		}

		/// <summary>
		/// Generates action which checks object public properties.
		/// </summary>
		/// <typeparam name="THolder">Anonymous object type.</typeparam>
		/// <typeparam name="TArg">Common arguments supertype used in <paramref name="createExceptionExpr" />.</typeparam>
		/// <typeparam name="T">Additional non-constant parameter type.</typeparam>
		/// <param name="propertyFilter">Object public properties filter; can be null to generate code for all the properties.</param>
		/// <param name="checkExprFunc">Function which generates property value check expression (if returns true then check is failed).
		/// Function obtains variable which holds property value and additional parameters.</param>
		/// <param name="createExceptionExpr">New exception creation expression used when check is failed.</param>
		/// <returns>Object check action.</returns>
		public static Action<THolder, T> Generate<THolder, TArg, T>(
			Func<Type, bool> propertyFilter,
			Func<ParameterExpression, IList<ParameterExpression>, Expr> checkExprFunc,
			Expression<Func<string, TArg, T, Exception>> createExceptionExpr)
		{
			return Generate<Action<THolder, T>>(propertyFilter, checkExprFunc, createExceptionExpr);
		}

		#endregion

		/// <summary>
		/// Generates action which checks object public properties.
		/// </summary>
		/// <typeparam name="TAction">Action type.</typeparam>
		/// <param name="propertyFilter">Object public properties filter; can be null to generate code for all the properties.</param>
		/// <param name="checkExpr">Property value check lambda expression; if returns true then check is failed.</param>
		/// <param name="createExceptionExpr">New exception creation expression used when check is failed.</param>
		/// <returns>Object check action.</returns>
		public static TAction Generate<TAction>(
		   Func<Type, bool> propertyFilter,
		   LambdaExpression checkExpr,
		   LambdaExpression createExceptionExpr) where TAction : class
		{
			VerifyUtil.NotNull(checkExpr, "checkExpr");

			var valueParam = checkExpr.Parameters[0];
			return Generate<TAction>(
				propertyFilter,
				(valueVar, additionalParams) =>
					checkExpr.ReplaceParams(additionalParams).Replace(valueParam, valueVar.ConvertIfNeeded(valueParam.Type)),
				createExceptionExpr);
		}

		/// <summary>
		/// Generates action which checks object public properties.
		/// </summary>
		/// <typeparam name="TAction">Action type.</typeparam>
		/// <param name="propertyFilter">Object public properties filter; can be null to generate code for all the properties.</param>
		/// <param name="checkExprFunc">Function which generates property value check expression (if returns true then check is failed).
		/// Function obtains variable which holds property value and additional parameters.</param>
		/// <param name="createExceptionExpr">New exception creation expression used when check is failed.</param>
		/// <returns>Object check action.</returns>
		public static TAction Generate<TAction>(
		   Func<Type, bool> propertyFilter,
		   Func<ParameterExpression, IList<ParameterExpression>, Expr> checkExprFunc,
		   LambdaExpression createExceptionExpr) where TAction : class
		{
			VerifyUtil.NotNull(checkExprFunc, "checkExprFunc");
			VerifyUtil.NotNull(createExceptionExpr, "createExceptionExpr");

			Type type = typeof(TAction).GetGenericArguments()[0];

			// Prepare lambda action parameters - first is object, others are additionalParamTypes
			var objectParam = Expr.Parameter(type);
			var additionalParams = typeof(TAction).GetGenericArguments().Skip(1).Select(Expr.Parameter).ToList();

			// Take createExceptionExpr lambda, extract first parameter from it and replace additional parameters in body
			var exceptionNameParam = createExceptionExpr.Parameters[0];
			var exceptionObjectParam = createExceptionExpr.Parameters[1];
			var exceptionBody = createExceptionExpr.ReplaceParams(additionalParams);

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
								checkExprFunc(valueVar, additionalParams),
								Expr.Throw(
									exceptionBody
										.Replace(exceptionNameParam, Expr.Constant(pi.Name))
										.Replace(exceptionObjectParam, valueVar.ConvertIfNeeded(exceptionObjectParam.Type)))));
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
