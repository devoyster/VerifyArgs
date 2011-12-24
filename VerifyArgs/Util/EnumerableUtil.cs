using System.Collections.Generic;

namespace VerifyArgs.Util
{
	/// <summary>
	/// Helpers for <see cref="IEnumerable{T}" />.
	/// </summary>
	internal static class EnumerableUtil
	{
		/// <summary>
		/// Adds given item prior to other enumerable items.
		/// </summary>
		/// <typeparam name="T">Item type.</typeparam>
		/// <param name="source">Enumerable items.</param>
		/// <param name="item">Item to add.</param>
		/// <returns>Enumerable with item added prior to other items.</returns>
		public static IEnumerable<T> Prepend<T>(this IEnumerable<T> source, T item)
		{
			yield return item;
			foreach (T value in source)
			{
				yield return value;
			}
		}
	}
}
