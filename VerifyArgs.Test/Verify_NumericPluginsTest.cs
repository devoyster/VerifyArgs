using System;
using NUnit.Framework;

namespace VerifyArgs.Test
{
	[TestFixture]
	public class Verify_NumericPluginsTest : NumericPluginsTestBase
	{
		protected override Action PositiveAction<T>(T holder)
		{
			return () => Verify.Positive(holder);
		}

		protected override Action NotNegativeAction<T>(T holder)
		{
			return () => Verify.NotNegative(holder);
		}

		protected override Action NegativeAction<T>(T holder)
		{
			return () => Verify.Negative(holder);
		}

		protected override Action NotPositiveAction<T>(T holder)
		{
			return () => Verify.NotPositive(holder);
		}
	}
}
