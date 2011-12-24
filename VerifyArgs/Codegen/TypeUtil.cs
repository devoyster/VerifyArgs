using System;
using System.Collections.Generic;

namespace VerifyArgs.Codegen
{
	/// <summary>
	/// Helpers for <see cref="Type" />.
	/// </summary>
	public static class TypeUtil
	{
		static readonly HashSet<Type>  NumericTypes = new HashSet<Type>(
			new[] { typeof(byte), typeof(short), typeof(ushort), typeof(int), typeof(uint), typeof(long), typeof(ulong), typeof(decimal), typeof(float), typeof(double) });

		/// <summary>
		/// Determines whether given type is numeric.
		/// </summary>
		/// <param name="type">Type to check.</param>
		/// <returns>True if type is numeric; false otherwise.</returns>
		public static bool IsNumeric(this Type type)
		{
			return NumericTypes.Contains(type);
		}
	}
}
