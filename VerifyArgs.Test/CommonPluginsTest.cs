using System;
using NUnit.Framework;
using SharpTestsEx;

namespace VerifyArgs.Test
{
	[TestFixture]
	public class CommonPluginsTest
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
			
			NotNullAction((object)null)
				.Should().Throw<ArgumentNullException>();

			NotNullAction(new { test = "123" })();
			NotNullAction(new { test = "123", test2 = 1 })();
		}

		[Test]
		public void NotEmpty()
		{
			NotEmptyAction(new { test = "" })
				.Should().Throw<ArgumentException>()
				.And.Exception.ParamName.Should().Be("test");
			NotEmptyAction(new { test = "", test2 = new int[0] })
				.Should().Throw<ArgumentException>()
				.And.Exception.ParamName.Should().Be("test");
			NotEmptyAction(new { test = "123", test2 = new int[0] })
				.Should().Throw<ArgumentException>()
				.And.Exception.ParamName.Should().Be("test2");

			NotEmptyAction((object)null)
				.Should().Throw<ArgumentNullException>();

			NotEmptyAction(new { test = "123" })();
			NotEmptyAction(new { test = "123", test2 = 1 })();
		}

		[Test]
		public void NotDefault()
		{
			NotDefaultAction(new { test = 0 })
				.Should().Throw<ArgumentException>()
				.And.Exception.ParamName.Should().Be("test");
			NotDefaultAction(new { test = Guid.Empty, test2 = DateTime.MinValue })
				.Should().Throw<ArgumentException>()
				.And.Exception.ParamName.Should().Be("test");
			NotDefaultAction(new { test = 1, test2 = DateTime.MinValue })
				.Should().Throw<ArgumentException>()
				.And.Exception.ParamName.Should().Be("test2");

			NotDefaultAction((object)null)
				.Should().Throw<ArgumentNullException>();

			NotDefaultAction(new { test = 1 })();
			NotDefaultAction(new { test = 1, test2 = "0", test3 = Guid.NewGuid() })();
		}

		[Test]
		public void NotNullOrEmpty()
		{
			NotNullOrEmptyAction(new { test = (string)null })
				.Should().Throw<ArgumentNullException>()
				.And.Exception.ParamName.Should().Be("test");
			NotNullOrEmptyAction(new { test = (string)null, test2 = (object)null })
				.Should().Throw<ArgumentNullException>()
				.And.Exception.ParamName.Should().Be("test");
			NotNullOrEmptyAction(new { test = "123", test2 = (object)null })
				.Should().Throw<ArgumentNullException>()
				.And.Exception.ParamName.Should().Be("test2");
			NotNullOrEmptyAction(new { test = "" })
				.Should().Throw<ArgumentException>()
				.And.Exception.ParamName.Should().Be("test");
			NotNullOrEmptyAction(new { test = "", test2 = new int[0] })
				.Should().Throw<ArgumentException>()
				.And.Exception.ParamName.Should().Be("test");
			NotNullOrEmptyAction(new { test = "123", test2 = new int[0] })
				.Should().Throw<ArgumentException>()
				.And.Exception.ParamName.Should().Be("test2");

			NotNullOrEmptyAction((object)null)
				.Should().Throw<ArgumentNullException>();

			NotNullOrEmptyAction(new { test = "123" })();
			NotNullOrEmptyAction(new { test = "123", test2 = 1 })();
		}

		private static Action NotNullAction<T>(T holder) where T : class
		{
			return Executing.This(() => Verify.Args(holder).NotNull());
		}

		private static Action NotEmptyAction<T>(T holder) where T : class
		{
			return Executing.This(() => Verify.Args(holder).NotEmpty());
		}

		private static Action NotDefaultAction<T>(T holder) where T : class
		{
			return Executing.This(() => Verify.Args(holder).NotDefault());
		}

		private static Action NotNullOrEmptyAction<T>(T holder) where T : class
		{
			return Executing.This(() => Verify.Args(holder).NotNullOrEmpty());
		}
	}
}
