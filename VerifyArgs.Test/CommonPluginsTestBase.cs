using System;
using NUnit.Framework;
using SharpTestsEx;

namespace VerifyArgs.Test
{
	public abstract class CommonPluginsTestBase
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

			NotDefaultAction(new { test = 1, test2 = (string)null })();
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

			NotNullOrEmptyAction(new { test = "123" })();
			NotNullOrEmptyAction(new { test = "123", test2 = 1 })();
		}

		protected abstract Action NotNullAction<T>(T holder) where T : class;

		protected abstract Action NotEmptyAction<T>(T holder) where T : class;

		protected abstract Action NotDefaultAction<T>(T holder) where T : class;

		protected abstract Action NotNullOrEmptyAction<T>(T holder) where T : class;
	}
}
