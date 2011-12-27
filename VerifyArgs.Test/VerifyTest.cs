using NUnit.Framework;
using SharpTestsEx;

namespace VerifyArgs.Test
{
	[TestFixture]
	public class VerifyTest
	{
		[Test]
		public void Args()
		{
			Arguments<string> args = Verify.Args("test");
			args.Holder.Should().Be("test");
		}
	}
}
