using System;
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
