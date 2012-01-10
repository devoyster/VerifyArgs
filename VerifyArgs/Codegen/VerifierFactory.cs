using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using VerifyArgs.Util;

using Expr = System.Linq.Expressions.Expression;

namespace VerifyArgs.Codegen
{
	using System.Reflection;

	/// <summary>
	/// Creates actions for argument checks.
	/// </summary>
	public static partial class VerifierFactory
	{
		private static readonly ConstructorInfo VerifyArgsExceptionCtor = typeof(VerifyArgsException).GetConstructor(new[] { typeof(string) });

		#region Generic wrappers

		/// <summary>
		/// Creates verifier which checks object public properties.
		/// </summary>
		/// <typeparam name="THolder">Anonymous object type.</typeparam>
		/// <typeparam name="TArg">Common arguments supertype used in <paramref name="checkExpr" /> and <paramref name="createExceptionExpr" />.</typeparam>
		/// <param name="propertyFilter">Object public properties filter; can be null to generate code for all the properties.</param>
		/// <param name="checkExpr">Property value check lambda expression; if returns true then check is failed.</param>
		/// <param name="createExceptionExpr">New exception creation expression used when check is failed.</param>
		/// <returns>Verifier instance.</returns>
		public static Func<Arguments<THolder>, Arguments<THolder>> Create<THolder, TArg>(
			Func<Type, bool> propertyFilter,
			Expression<Func<TArg, bool>> checkExpr,
			Expression<Func<string, TArg, Exception>> createExceptionExpr) where THolder : class
		{
			return Create<Func<Arguments<THolder>, Arguments<THolder>>>(propertyFilter, checkExpr, createExceptionExpr);
		}

		/// <summary>
		/// Creates verifier which checks object public properties.
		/// </summary>
		/// <typeparam name="THolder">Anonymous object type.</typeparam>
		/// <typeparam name="TArg">Common arguments supertype used in <paramref name="createExceptionExpr" />.</typeparam>
		/// <param name="propertyFilter">Object public properties filter; can be null to generate code for all the properties.</param>
		/// <param name="checkExprFunc">Function which generates property value check expression (if returns true then check is failed).
		/// Function obtains variable which holds property value and additional arguments.</param>
		/// <param name="createExceptionExpr">New exception creation expression used when check is failed.</param>
		/// <returns>Verifier instance.</returns>
		public static Func<Arguments<THolder>, Arguments<THolder>> Create<THolder, TArg>(
			Func<Type, bool> propertyFilter,
			Func<Expression, IList<ParameterExpression>, Expr> checkExprFunc,
			Expression<Func<string, TArg, Exception>> createExceptionExpr) where THolder : class
		{
			return Create<Func<Arguments<THolder>, Arguments<THolder>>>(propertyFilter, checkExprFunc, createExceptionExpr);
		}

		/// <summary>
		/// Creates verifier which checks object public properties.
		/// </summary>
		/// <typeparam name="THolder">Anonymous object type.</typeparam>
		/// <typeparam name="TArg">Common arguments supertype used in <paramref name="checkExpr" /> and <paramref name="createExceptionExpr" />.</typeparam>
		/// <typeparam name="T">Additional non-constant argument type.</typeparam>
		/// <param name="propertyFilter">Object public properties filter; can be null to generate code for all the properties.</param>
		/// <param name="checkExpr">Property value check lambda expression; if returns true then check is failed.</param>
		/// <param name="createExceptionExpr">New exception creation expression used when check is failed.</param>
		/// <returns>Verifier instance.</returns>
		public static Func<Arguments<THolder>, T, Arguments<THolder>> Create<THolder, TArg, T>(
			Func<Type, bool> propertyFilter,
			Expression<Func<TArg, T, bool>> checkExpr,
			Expression<Func<string, TArg, T, Exception>> createExceptionExpr) where THolder : class
		{
			return Create<Func<Arguments<THolder>, T, Arguments<THolder>>>(propertyFilter, checkExpr, createExceptionExpr);
		}

		/// <summary>
		/// Creates verifier which checks object public properties.
		/// </summary>
		/// <typeparam name="THolder">Anonymous object type.</typeparam>
		/// <typeparam name="TArg">Common arguments supertype used in <paramref name="createExceptionExpr" />.</typeparam>
		/// <typeparam name="T">Additional non-constant argument type.</typeparam>
		/// <param name="propertyFilter">Object public properties filter; can be null to generate code for all the properties.</param>
		/// <param name="checkExprFunc">Function which generates property value check expression (if returns true then check is failed).
		/// Function obtains variable which holds property value and additional arguments.</param>
		/// <param name="createExceptionExpr">New exception creation expression used when check is failed.</param>
		/// <returns>Verifier instance.</returns>
		public static Func<Arguments<THolder>, T, Arguments<THolder>> Create<THolder, TArg, T>(
			Func<Type, bool> propertyFilter,
			Func<Expression, IList<ParameterExpression>, Expr> checkExprFunc,
			Expression<Func<string, TArg, T, Exception>> createExceptionExpr) where THolder : class
		{
			return Create<Func<Arguments<THolder>, T, Arguments<THolder>>>(propertyFilter, checkExprFunc, createExceptionExpr);
		}

		#endregion
		
		/// <summary>
		/// Creates verifier which checks object public properties.
		/// </summary>
		/// <typeparam name="TVerifier">Verifier type.</typeparam>
		/// <param name="propertyFilter">Object public properties filter; can be null to generate code for all the properties.</param>
		/// <param name="checkExpr">Property value check lambda expression; if returns true then check is failed.</param>
		/// <param name="createExceptionExpr">New exception creation expression used when check is failed.</param>
		/// <returns>Verifier instance.</returns>
		public static TVerifier Create<TVerifier>(
		   Func<Type, bool> propertyFilter,
		   LambdaExpression checkExpr,
		   LambdaExpression createExceptionExpr) where TVerifier : class
		{
			VerifyUtil.NotNull(checkExpr, "checkExpr");

			var valueParam = checkExpr.Parameters[0];
			return Create<TVerifier>(
				propertyFilter,
				(valueVar, additionalParams) =>
					checkExpr
						.ReplaceParams(additionalParams)
						.Replace(valueParam, valueVar.ConvertIfNeeded(valueParam.Type)),
				createExceptionExpr);
		}

		/// <summary>
		/// Creates verifier which checks object public properties.
		/// </summary>
		/// <typeparam name="TVerifier">Verifier type.</typeparam>
		/// <param name="propertyFilter">Object public properties filter; can be null to generate code for all the properties.</param>
		/// <param name="checkExprFunc">Function which generates property value check expression (if returns true then check is failed).
		/// Function obtains variable which holds property value and additional arguments.</param>
		/// <param name="createExceptionExpr">New exception creation expression used when check is failed.</param>
		/// <returns>Verifier instance.</returns>
		public static TVerifier Create<TVerifier>(
		   Func<Type, bool> propertyFilter,
		   Func<Expression, IList<ParameterExpression>, Expr> checkExprFunc,
		   LambdaExpression createExceptionExpr) where TVerifier : class
		{
			VerifyUtil.NotNull(checkExprFunc, "checkExprFunc");
			VerifyUtil.NotNull(createExceptionExpr, "createExceptionExpr");

			Type argumentsType = typeof(TVerifier).GetGenericArguments()[0];
			Type type = argumentsType.GetGenericArguments()[0];

			// Prepare lambda action parameters - first is Argument<T>, others are additionalParamTypes
			var objectParam = Expr.Parameter(argumentsType);
			var objectVar = Expr.Parameter(type);
			var genericArguments = typeof(TVerifier).GetGenericArguments();
			var additionalParams = genericArguments.Skip(1).Take(genericArguments.Length - 2).Select(Expr.Parameter).ToList();

			Expr lambdaBody;
			if (type.IsAnonymous())
			{
				// Take createExceptionExpr lambda, extract first parameter from it and replace additional parameters in body
				var exceptionNameParam = createExceptionExpr.Parameters[0];
				var exceptionObjectParam = createExceptionExpr.Parameters[1];
				var exceptionBody = createExceptionExpr.ReplaceParams(additionalParams);

				// Obtain type public properties to check
				propertyFilter = propertyFilter ?? (_ => true);
				var properties = type.GetProperties().OrderBy(pi => pi.Name).Where(pi => propertyFilter(pi.PropertyType));

				// Obtain argument values from fields since it's faster
				var fields = type.GetFields(BindingFlags.NonPublic | BindingFlags.Instance).OrderBy(fi => fi.Name).Where(fi => propertyFilter(fi.FieldType)).ToList();

				// Generate "if (checkExpr) then throw createExceptionExpr;" for each of the properties
				var propertyChecks = properties
					.Select(
						(pi, i) =>
						{
							var valueVar = Expr.Field(objectVar, fields[i]);
							return Expr.IfThen(
								checkExprFunc(valueVar, additionalParams),
								Expr.Throw(
									exceptionBody
										.Replace(exceptionNameParam, Expr.Constant(pi.Name))
										.Replace(exceptionObjectParam, valueVar.ConvertIfNeeded(exceptionObjectParam.Type))));
						})
					.ToList();

				// Prepare null check - if null is supplied then all checks are passed since nothing to check
				var checksBody = propertyChecks.Any()
					? Expr.IfThen(
						Expr.ReferenceNotEqual(objectVar, Expr.Constant(null, type)),
						propertyChecks.Count > 1 ? (Expr)Expr.Block(propertyChecks) : propertyChecks[0])
					: null;

				lambdaBody = propertyChecks.Any()
					? (Expr)Expr.Block(
						new[] { objectVar },
						new Expr[] { Expr.Assign(objectVar, Expr.Field(objectParam, "Holder")) }
							.Concat(new[] { checksBody })
							.Concat(new[] { objectParam }))
					: objectParam;
			}
			else
			{
				// Not anonymous type - throw an exception
				lambdaBody = Expr.Block(
					Expr.Throw(
						Expr.New(
							VerifyArgsExceptionCtor,
							Expr.Constant(string.Format(ErrorMessages.NotAnonymousType, type)))),
					objectParam);
			}

			// Pull it all together, execute checks only if supplied object is not null
			var lambda = Expr.Lambda<TVerifier>(
				lambdaBody,
				new[] { objectParam }.Concat(additionalParams));
			return lambda.Compile();
		}
	}
}
