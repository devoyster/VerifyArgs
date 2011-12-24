using System.Linq.Expressions;

namespace VerifyArgs.Util
{
	/// <summary>
	///  Replaces expression instance with another expression instance.
	/// </summary>
	internal sealed class ReplaceExpressionVisitor : ExpressionVisitor
	{
		private readonly Expression _original;
		private readonly Expression _replacement;

		/// <summary>
		/// Creates new <see cref="ReplaceExpressionVisitor" /> instance.
		/// </summary>
		/// <param name="original">Expression to replace.</param>
		/// <param name="replacement">target expression.</param>
		public ReplaceExpressionVisitor(Expression original, Expression replacement)
		{
			_original = original;
			_replacement = replacement;
		}

		/// <summary>
		/// Visits expression node and replaces it with another node if found in <see cref="Replacements" />.
		/// </summary>
		/// <param name="node">Node to visit.</param>
		/// <returns>Original or replaced node.</returns>
		public override Expression Visit(Expression node)
		{
			return node == _original ? _replacement : base.Visit(node);
		}
	}
}
