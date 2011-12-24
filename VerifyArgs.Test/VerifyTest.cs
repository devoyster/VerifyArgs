using System;
using NUnit.Framework;
using SharpTestsEx;

namespace VerifyArgs.Test
{
	[TestFixture]
	public class VerifyTest
	{
		[Test]
		public void NotNull()
		{
			NotNullAction(new { test = (string)null })
				.Should().Throw<ArgumentNullException>()
				.And.Exception.ParamName.Should().Be("test");
			NotNullAction(new { test = (string)null, test2 = (object)null })
				.Should().Throw<ArgumentNullException>()
				.And.Exception.ParamName.Should().Be("test");
			NotNullAction(new { test = "123", test2 = (object)null })
				.Should().Throw<ArgumentNullException>()
				.And.Exception.ParamName.Should().Be("test2");

			NotNullAction((object)null)();
			NotNullAction(new { test = "123" })();
			NotNullAction(new { test = "123", test2 = 1 })();
		}

		/*[Test]
		public void NotEmpty()
		{
			Func<object, Action> exec = obj => () => Verify.NotEmpty(obj);
			exec(new { test = "" })
				.Should().Throw<ArgumentException>()
				.And.Exception.ParamName.Should().Be("test");
			exec(new { test = "", test2 = new int[0] })
				.Should().Throw<ArgumentException>()
				.And.Exception.ParamName.Should().Be("test");
			exec(new { test = "123", test2 = new int[0] })
				.Should().Throw<ArgumentException>()
				.And.Exception.ParamName.Should().Be("test2");

			Verify.NotEmpty(null);
			Verify.NotEmpty(new { test = "123" });
			Verify.NotEmpty(new { test = "123", test2 = 1 });
		}

		[Test]
		public void NotNullOrEmpty()
		{
			Func<object, Action> exec = obj => () => Verify.NotNullOrEmpty(obj);
			exec(new { test = (string)null })
				.Should().Throw<ArgumentNullException>()
				.And.Exception.ParamName.Should().Be("test");
			exec(new { test = (string)null, test2 = (object)null })
				.Should().Throw<ArgumentNullException>()
				.And.Exception.ParamName.Should().Be("test");
			exec(new { test = "123", test2 = (object)null })
				.Should().Throw<ArgumentNullException>()
				.And.Exception.ParamName.Should().Be("test2");
			exec(new { test = "" })
				.Should().Throw<ArgumentException>()
				.And.Exception.ParamName.Should().Be("test");
			exec(new { test = "", test2 = new int[0] })
				.Should().Throw<ArgumentException>()
				.And.Exception.ParamName.Should().Be("test");
			exec(new { test = "123", test2 = new int[0] })
				.Should().Throw<ArgumentException>()
				.And.Exception.ParamName.Should().Be("test2");

			Verify.NotNullOrEmpty(null);
			Verify.NotNullOrEmpty(new { test = "123" });
			Verify.NotNullOrEmpty(new { test = "123", test2 = 1 });
		}

		[Test]
		public void IsGreaterThan()
		{
			Func<object, Action> exec = obj => () => Verify.GreaterThan(obj, 10);
			exec(new { test = (string)null, test2 = 8 })
				.Should().Throw<ArgumentOutOfRangeException>();
		}*/

		private Action NotNullAction<T>(T holder) where T : class
		{
			return Executing.This(() => Verify.Args(holder).NotNull());
		}
	}
}
