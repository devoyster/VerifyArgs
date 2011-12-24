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

	/*#region NotEmpty()

	static public class NotEmptyPlugin
	{
		private static readonly Func<Type, Action<object>> Generator = GenFactory.CreateGenerator<IEnumerable>(
			t => typeof(IEnumerable).IsAssignableFrom(t),
			x => x != null && !x.GetEnumerator().MoveNext(),
			(n, _) => new ArgumentException("Value can't be empty.", n));

		static public IArguments NotEmpty(this IArguments args)
		{
			return args.Verify(Generator);
		}
	}

	#endregion

	#region NotNullOrEmpty()

	static public class NotNullOrEmptyPlugin
	{
		static public IArguments NotNullOrEmpty(this IArguments args)
		{
			return args.NotNull().NotEmpty();
		}
	}

	#endregion

	#region GreaterThan()

	static public class GreaterThanPlugin
	{
		private static readonly Func<Type, Action<object, decimal>> Generator = GenFactory.CreateGenerator<int, decimal>(
			TypeUtil.IsNumeric,
			(x, min) => x <= min,
			(n, x, min) => new ArgumentOutOfRangeException(n, x, string.Format("Value should be greater than {0}.", min)));

		static public IArguments GreaterThan(this IArguments args, decimal min)
		{
			return args.Verify(Generator, min);
		}
	}

	#endregion*/
}
