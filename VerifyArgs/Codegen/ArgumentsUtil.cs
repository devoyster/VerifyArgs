using System;

namespace VerifyArgs.Codegen
{
	/// <summary>
	/// Helpers for <see cref="IArguments" />.
	/// </summary>
	public static partial class ArgumentsUtil
	{
		public static IArguments Verify(this IArguments args, Func<Type, Action<object>> generator)
		{
			if (generator == null)
			{
				throw new ArgumentNullException("generator");
			}

			if (args.Holder != null)
			{
				generator(args.Holder.GetType())(args.Holder);
			}
			return args;
		}

		public static IArguments Verify<T>(this IArguments args, Func<Type, Action<object, T>> generator, T param)
		{
			if (generator == null)
			{
				throw new ArgumentNullException("generator");
			}

			if (args.Holder != null)
			{
				generator(args.Holder.GetType())(args.Holder, param);
			}
			return args;
		}
	}
}
