using System;
using System.Collections;
using VerifyArgs.Codegen;

namespace VerifyArgs
{
	#region NotNull()

	public static class NotNullPlugin
	{
		private static class Check<T> where T : class
		{
			public static readonly Action<T> Action = ActionFactory.Generate<T, object>(
				t => !t.IsValueType,
				x => x == null,
				(n, _) => new ArgumentNullException(n));
		}

		static public IArguments<T> NotNull<T>(this IArguments<T> args) where T : class
		{
			Check<T>.Action(args.Holder);
			return args;
		}
	}

	#endregion

	#region NotEmpty()

	static public class NotEmptyPlugin
	{
		private static class Check<T> where T : class
		{
			public static readonly Action<T> Action = ActionFactory.Generate<T, IEnumerable>(
				t => typeof(IEnumerable).IsAssignableFrom(t),
				x => x != null && !((IEnumerable)x).GetEnumerator().MoveNext(),
				(n, _) => new ArgumentException("Value can't be empty.", n));
		}

		static public IArguments<T> NotEmpty<T>(this IArguments<T> args) where T : class
		{
			Check<T>.Action(args.Holder);
			return args;
		}
	}

	#endregion

	#region NotNullOrEmpty()

	static public class NotNullOrEmptyPlugin
	{
		static public IArguments<T> NotNullOrEmpty<T>(this IArguments<T> args) where T : class
		{
			return args.NotNull().NotEmpty();
		}
	}

	#endregion
}
