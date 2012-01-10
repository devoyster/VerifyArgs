using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using VerifyArgs.Util;

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
			VerifyUtil.NotNull(type, "type");
			return NumericTypes.Contains(type);
		}

		/// <summary>
		/// Determines whether given type has public property.
		/// </summary>
		/// <param name="type">Type to check.</param>
		/// <param name="propertyName">Public property name.</param>
		/// <returns>True if type has <paramref name="propertyName" /> property; false otherwise.</returns>
		public static bool HasProperty(this Type type, string propertyName)
		{
			VerifyUtil.NotNull(type, "type");
			VerifyUtil.NotNull(propertyName, "propertyName");
			return type.GetProperty(propertyName) != null;
		}

		/// <summary>
		/// Determines whether given type has "Length" or "Count" public property.
		/// </summary>
		/// <param name="type">Type to check.</param>
		/// <returns>True if type has "Length" and/or "Count" property; false otherwise.</returns>
		public static bool HasLengthProperty(this Type type)
		{
			VerifyUtil.NotNull(type, "type");
			return type.HasProperty("Length") || type.HasProperty("Count");
		}

		/// <summary>
		/// Tries to determine whether given type is anonymous type.
		/// </summary>
		/// <param name="type">Type to check.</param>
		/// <returns>True if type is presumably anonymous; false if it's not anonymous for sure.</returns>
		internal static bool IsAnonymous(this Type type)
		{
			VerifyUtil.NotNull(type, "type");
			return
				!type.IsVisible && type.IsSealed &&
				string.IsNullOrEmpty(type.Namespace) && type.Name.StartsWith("<>f__AnonymousType") &&
				Attribute.IsDefined(type, typeof(CompilerGeneratedAttribute));
		}
	}
}
