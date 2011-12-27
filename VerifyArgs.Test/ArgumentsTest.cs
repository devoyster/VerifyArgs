using NUnit.Framework;
using SharpTestsEx;

namespace VerifyArgs.Test
{
	[TestFixture]
	public class ArgumentsTest
	{
		[Test]
		public void Ctor()
		{
			new Arguments<string>(null).Holder.Should().Be.Null();
			new Arguments<string>("test").Holder.Should().Be("test");
		}
	}
}
