using System;
using NUnit.Framework;

namespace VerifyArgs.Test
{
	[TestFixture]
	public class Verify_CommonPluginsTest : CommonPluginsTestBase
	{
		protected override Action NotNullAction<T>(T holder)
		{
			return () => Verify.NotNull(holder);
		}

		protected override Action NotEmptyAction<T>(T holder)
		{
			return () => Verify.NotEmpty(holder);
		}

		protected override Action NotDefaultAction<T>(T holder)
		{
			return () => Verify.NotDefault(holder);
		}

		protected override Action NotNullOrEmptyAction<T>(T holder)
		{
			return () => Verify.NotNullOrEmpty(holder);
		}
	}
}
