using System;
using NUnit.Framework;
using SharpTestsEx;

namespace VerifyArgs.Test
{
	[TestFixture]
	public class NumericPluginsTest : NumericPluginsTestBase
	{
		[Test]
		public void MinValue()
		{
			MinValueAction(new { test = 0 }, 1)
				.Should().Throw<ArgumentOutOfRangeException>()
				.And.Exception.ParamNameShouldBe("test");
			MinValueAction(new { test = 0, test2 = 0.0 }, 1)
				.Should().Throw<ArgumentOutOfRangeException>()
				.And.Exception.ParamNameShouldBe("test");
			MinValueAction(new { test = 2, test2 = 0.5 }, 1)
				.Should().Throw<ArgumentOutOfRangeException>()
				.And.Exception.ParamNameShouldBe("test2");

			MinValueAction(new { test = 1 }, 1)();
			MinValueAction(new { test = 1, test2 = 2.0 }, 1)();
		}

		[Test]
		public void MaxValue()
		{
			MaxValueAction(new { test = 2 }, 1)
				.Should().Throw<ArgumentOutOfRangeException>()
				.And.Exception.ParamNameShouldBe("test");
			MaxValueAction(new { test = 2, test2 = 2.0 }, 1)
				.Should().Throw<ArgumentOutOfRangeException>()
				.And.Exception.ParamNameShouldBe("test");
			MaxValueAction(new { test = 0, test2 = 1.5 }, 1)
				.Should().Throw<ArgumentOutOfRangeException>()
				.And.Exception.ParamNameShouldBe("test2");

			MaxValueAction(new { test = 1 }, 1)();
			MaxValueAction(new { test = 1, test2 = 0.0 }, 1)();
		}

		[Test]
		public void InRange()
		{
			InRangeAction(new { test = 2 }, 4, 3)
				.Should().Throw<ArgumentOutOfRangeException>()
				.And.Exception.ParamNameShouldBe("test");
			InRangeAction(new { test = 2 }, 3, 3)
				.Should().Throw<ArgumentOutOfRangeException>()
				.And.Exception.ParamNameShouldBe("test");
			InRangeAction(new { test = 1 }, 2, 4)
				.Should().Throw<ArgumentOutOfRangeException>()
				.And.Exception.ParamNameShouldBe("test");
			InRangeAction(new { test = 5 }, 2, 4)
				.Should().Throw<ArgumentOutOfRangeException>()
				.And.Exception.ParamNameShouldBe("test");
			InRangeAction(new { test = 1, test2 = 1.0 }, 2, 4)
				.Should().Throw<ArgumentOutOfRangeException>()
				.And.Exception.ParamNameShouldBe("test");
			InRangeAction(new { test = 3, test2 = 4.5 }, 2, 4)
				.Should().Throw<ArgumentOutOfRangeException>()
				.And.Exception.ParamNameShouldBe("test2");

			InRangeAction(new { test = 3 }, 3, 3)();
			InRangeAction(new { test = 2 }, 2, 4)();
			InRangeAction(new { test = 3, test2 = 4.0 }, 2, 4)();
		}

		private static Action MinValueAction<T>(T holder, decimal min) where T : class
		{
			return () => Verify.Args(holder).MinValue(min);
		}

		private static Action MaxValueAction<T>(T holder, decimal max) where T : class
		{
			return () => Verify.Args(holder).MaxValue(max);
		}

		private static Action InRangeAction<T>(T holder, decimal min, decimal max) where T : class
		{
			return () => Verify.Args(holder).InRange(min, max);
		}

		protected override Action PositiveAction<T>(T holder)
		{
			return () => Verify.Args(holder).Positive();
		}

		protected override Action NotNegativeAction<T>(T holder)
		{
			return () => Verify.Args(holder).NotNegative();
		}

		protected override Action NegativeAction<T>(T holder)
		{
			return () => Verify.Args(holder).Negative();
		}

		protected override Action NotPositiveAction<T>(T holder)
		{
			return () => Verify.Args(holder).NotPositive();
		}
	}
}
