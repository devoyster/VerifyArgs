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
			if (original == null)
			{
				throw new ArgumentNullException("original");
			}
			if (replacement == null)
			{
				throw new ArgumentNullException("replacement");
			}
			return new ReplaceExpressionVisitor(original, replacement).Visit(node);
		}
	}
}
