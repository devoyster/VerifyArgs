using System;
using NUnit.Framework;
using SharpTestsEx;

namespace VerifyArgs.Test
{
	public abstract class NumericPluginsTestBase
	{
		[Test]
		public void Positive()
		{
			PositiveAction(new { test = -1 })
				.Should().Throw<ArgumentOutOfRangeException>()
				.And.Exception.ParamName.Should().Be("test");
			PositiveAction(new { test = 0 })
				.Should().Throw<ArgumentOutOfRangeException>()
				.And.Exception.ParamName.Should().Be("test");
			PositiveAction(new { test = -1, test2 = -1.0 })
				.Should().Throw<ArgumentOutOfRangeException>()
				.And.Exception.ParamName.Should().Be("test");
			PositiveAction(new { test = 1, test2 = 0 })
				.Should().Throw<ArgumentOutOfRangeException>()
				.And.Exception.ParamName.Should().Be("test2");

			PositiveAction(new { test = 1 })();
			PositiveAction(new { test = 1, test2 = 2.0 })();
		}

		[Test]
		public void NotNegative()
		{
			NotNegativeAction(new { test = -1 })
				.Should().Throw<ArgumentOutOfRangeException>()
				.And.Exception.ParamName.Should().Be("test");
			NotNegativeAction(new { test = -1, test2 = -1.0 })
				.Should().Throw<ArgumentOutOfRangeException>()
				.And.Exception.ParamName.Should().Be("test");
			NotNegativeAction(new { test = 1, test2 = -0.5 })
				.Should().Throw<ArgumentOutOfRangeException>()
				.And.Exception.ParamName.Should().Be("test2");

			NotNegativeAction(new { test = 0 })();
			NotNegativeAction(new { test = 0, test2 = 1.0 })();
		}

		[Test]
		public void Negative()
		{
			NegativeAction(new { test = 1 })
				.Should().Throw<ArgumentOutOfRangeException>()
				.And.Exception.ParamName.Should().Be("test");
			NegativeAction(new { test = 0 })
				.Should().Throw<ArgumentOutOfRangeException>()
				.And.Exception.ParamName.Should().Be("test");
			NegativeAction(new { test = 1, test2 = 1.0 })
				.Should().Throw<ArgumentOutOfRangeException>()
				.And.Exception.ParamName.Should().Be("test");
			NegativeAction(new { test = -1, test2 = 0.0 })
				.Should().Throw<ArgumentOutOfRangeException>()
				.And.Exception.ParamName.Should().Be("test2");

			NegativeAction(new { test = -1 })();
			NegativeAction(new { test = -1, test2 = -2.0 })();
		}

		[Test]
		public void NotPositive()
		{
			NotPositiveAction(new { test = 1 })
				.Should().Throw<ArgumentOutOfRangeException>()
				.And.Exception.ParamName.Should().Be("test");
			NotPositiveAction(new { test = 1, test2 = 1.0 })
				.Should().Throw<ArgumentOutOfRangeException>()
				.And.Exception.ParamName.Should().Be("test");
			NotPositiveAction(new { test = 0, test2 = 0.5 })
				.Should().Throw<ArgumentOutOfRangeException>()
				.And.Exception.ParamName.Should().Be("test2");

			NotPositiveAction(new { test = 0 })();
			NotPositiveAction(new { test = 0, test2 = -1.0 })();
		}

		protected abstract Action PositiveAction<T>(T holder) where T : class;

		protected abstract Action NotNegativeAction<T>(T holder) where T : class;

		protected abstract Action NegativeAction<T>(T holder) where T : class;

		protected abstract Action NotPositiveAction<T>(T holder) where T : class;
	}
}
