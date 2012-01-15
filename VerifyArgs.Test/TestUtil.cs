using System;
using SharpTestsEx;

namespace VerifyArgs.Test
{
	public static class TestUtil
	{
		public static void ParamNameShouldBe(this ArgumentNullException exception, string expected)
		{
#if NETFW
			exception.ParamName.Should().Be(expected);
#endif
		}

		public static void ParamNameShouldBe(this ArgumentException exception, string expected)
		{
#if NETFW
			exception.ParamName.Should().Be(expected);
#endif
		}

		public static void ParamNameShouldBe(this ArgumentOutOfRangeException exception, string expected)
		{
#if NETFW
			exception.ParamName.Should().Be(expected);
#endif
		}
	}
}
