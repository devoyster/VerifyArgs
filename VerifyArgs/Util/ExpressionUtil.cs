using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace VerifyArgs.Util
{
	/// <summary>
	/// Helpers for <see cref="Expression" />.
	/// </summary>
	internal static class ExpressionUtil
	{
		/// <summary>
		/// Replaces expressions in given expression tree.
		/// </summary>
		/// <param name="node">Expression tree to transform.</param>
		/// <param name="original">Original expression.</param>
		/// <param name="replacement">Replacement expression.</param>
		/// <returns>Transformed <paramref name="node" />.</returns>
		public static Expression Replace(this Expression node, Expression original, Expression replacement)
		{
			VerifyUtil.NotNull(original, "original");
			VerifyUtil.NotNull(replacement, "replacement");
			return new ReplaceExpressionVisitor(original, replacement).Visit(node);
		}

		/// <summary>
		/// Replaces last N lambda expression parameters with provided N parameters
		/// </summary>
		/// <param name="lambda">Lambda expression which parameters to replace.</param>
		/// <param name="replacementParams">N replacement parameters.</param>
		/// <returns>Lambda expression body with parameters replaced.</returns>
		public static Expression ReplaceParams(this LambdaExpression lambda, IList<ParameterExpression> replacementParams)
		{
			VerifyUtil.NotNull(replacementParams, "replacementParams");
			return lambda
				.Parameters
				.Skip(lambda.Parameters.Count - replacementParams.Count)
				.Zip(replacementParams, (from, to) => new { from, to })
				.Aggregate(lambda.Body, (body, x) => body.Replace(x.from, x.to));
		}

		/// <summary>
		/// Wraps expression into convert expression but only if expression is not of given type.
		/// </summary>
		/// <param name="node">Expression to convert.</param>
		/// <param name="newType">Type to convert to.</param>
		/// <returns>Converted expression.</returns>
		public static Expression ConvertIfNeeded(this Expression node, Type newType)
		{
			VerifyUtil.NotNull(newType, "newType");
			return node.Type != newType ? Expression.Convert(node, newType) : node;
		}
	}
}
