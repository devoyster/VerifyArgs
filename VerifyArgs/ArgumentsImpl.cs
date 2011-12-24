namespace VerifyArgs
{
	/// <summary>
	/// Arguments holder implementation.
	/// </summary>
	internal sealed class ArgumentsImpl : IArguments
	{
		private readonly object _holder;

		/// <summary>
		/// Creates new <see cref="ArgumentsImpl" /> instance.
		/// </summary>
		/// <param name="holder"></param>
		public ArgumentsImpl(object holder)
		{
			_holder = holder;
		}

		/// <summary>
		/// Gets anonymous object which contains arguments to verify.
		/// </summary>
		public object Holder
		{
			get { return _holder; }
		}
	}
}
