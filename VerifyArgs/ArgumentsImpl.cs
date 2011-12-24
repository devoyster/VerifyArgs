namespace VerifyArgs
{
	/// <summary>
	/// Arguments holder implementation.
	/// </summary>
	/// <typeparam name="THolder">Anonymous object type.</typeparam>
	internal sealed class ArgumentsImpl<THolder> : IArguments<THolder> where THolder : class
	{
		private readonly THolder _holder;

		/// <summary>
		/// Creates new <see cref="ArgumentsImpl{THolder}" /> instance.
		/// </summary>
		/// <param name="holder">Anonymous object which contains arguments to verify.</param>
		public ArgumentsImpl(THolder holder)
		{
			_holder = holder;
		}

		/// <summary>
		/// Gets anonymous object which contains arguments to verify.
		/// </summary>
		public THolder Holder
		{
			get { return _holder; }
		}
	}
}
