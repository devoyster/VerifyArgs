using System;
using NUnit.Framework;
using SharpTestsEx;

namespace VerifyArgs.Test
{
	[TestFixture]
	public class NumericPluginsTest
	{
		[Test]
		public void GreaterThan()
		{
			GreaterThanAction(new { test = 0 }, 1)
				.Should().Throw<ArgumentOutOfRangeException>()
				.And.Exception.ParamName.Should().Be("test");
			GreaterThanAction(new { test = 1 }, 1)
				.Should().Throw<ArgumentOutOfRangeException>()
				.And.Exception.ParamName.Should().Be("test");
			GreaterThanAction(new { test = 0, test2 = 0.0 }, 1)
				.Should().Throw<ArgumentOutOfRangeException>()
				.And.Exception.ParamName.Should().Be("test");
			GreaterThanAction(new { test = 2, test2 = 1 }, 1)
				.Should().Throw<ArgumentOutOfRangeException>()
				.And.Exception.ParamName.Should().Be("test2");

			GreaterThanAction(new { test = 2 }, 1)();
			GreaterThanAction(new { test = 2, test2 = 3.0 }, 1)();
		}

		[Test]
		public void GreaterThanOrEqual()
		{
			GreaterThanOrEqualAction(new { test = 0 }, 1)
				.Should().Throw<ArgumentOutOfRangeException>()
				.And.Exception.ParamName.Should().Be("test");
			GreaterThanOrEqualAction(new { test = 0, test2 = 0.0 }, 1)
				.Should().Throw<ArgumentOutOfRangeException>()
				.And.Exception.ParamName.Should().Be("test");
			GreaterThanOrEqualAction(new { test = 2, test2 = 0.5 }, 1)
				.Should().Throw<ArgumentOutOfRangeException>()
				.And.Exception.ParamName.Should().Be("test2");

			GreaterThanOrEqualAction(new { test = 1 }, 1)();
			GreaterThanOrEqualAction(new { test = 1, test2 = 2.0 }, 1)();
		}

		[Test]
		public void LessThan()
		{
			LessThanAction(new { test = 2 }, 1)
				.Should().Throw<ArgumentOutOfRangeException>()
				.And.Exception.ParamName.Should().Be("test");
			LessThanAction(new { test = 1 }, 1)
				.Should().Throw<ArgumentOutOfRangeException>()
				.And.Exception.ParamName.Should().Be("test");
			LessThanAction(new { test = 2, test2 = 2.0 }, 1)
				.Should().Throw<ArgumentOutOfRangeException>()
				.And.Exception.ParamName.Should().Be("test");
			LessThanAction(new { test = 0, test2 = 1.0 }, 1)
				.Should().Throw<ArgumentOutOfRangeException>()
				.And.Exception.ParamName.Should().Be("test2");

			LessThanAction(new { test = 0 }, 1)();
			LessThanAction(new { test = 0, test2 = -1.0 }, 1)();
		}

		[Test]
		public void LessThanOrEqual()
		{
			LessThanOrEqualAction(new { test = 2 }, 1)
				.Should().Throw<ArgumentOutOfRangeException>()
				.And.Exception.ParamName.Should().Be("test");
			LessThanOrEqualAction(new { test = 2, test2 = 2.0 }, 1)
				.Should().Throw<ArgumentOutOfRangeException>()
				.And.Exception.ParamName.Should().Be("test");
			LessThanOrEqualAction(new { test = 0, test2 = 1.5 }, 1)
				.Should().Throw<ArgumentOutOfRangeException>()
				.And.Exception.ParamName.Should().Be("test2");

			LessThanOrEqualAction(new { test = 1 }, 1)();
			LessThanOrEqualAction(new { test = 1, test2 = 0.0 }, 1)();
		}

		[Test]
		public void InRange()
		{
			InRangeAction(new { test = 2 }, 4, 3)
				.Should().Throw<ArgumentOutOfRangeException>()
				.And.Exception.ParamName.Should().Be("test");
			InRangeAction(new { test = 2 }, 3, 3)
				.Should().Throw<ArgumentOutOfRangeException>()
				.And.Exception.ParamName.Should().Be("test");
			InRangeAction(new { test = 1 }, 2, 4)
				.Should().Throw<ArgumentOutOfRangeException>()
				.And.Exception.ParamName.Should().Be("test");
			InRangeAction(new { test = 5 }, 2, 4)
				.Should().Throw<ArgumentOutOfRangeException>()
				.And.Exception.ParamName.Should().Be("test");
			InRangeAction(new { test = 1, test2 = 1.0 }, 2, 4)
				.Should().Throw<ArgumentOutOfRangeException>()
				.And.Exception.ParamName.Should().Be("test");
			InRangeAction(new { test = 3, test2 = 4.5 }, 2, 4)
				.Should().Throw<ArgumentOutOfRangeException>()
				.And.Exception.ParamName.Should().Be("test2");

			InRangeAction(new { test = 3 }, 3, 3)();
			InRangeAction(new { test = 2 }, 2, 4)();
			InRangeAction(new { test = 3, test2 = 4.0 }, 2, 4)();
		}

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

		private static Action GreaterThanAction<T>(T holder, decimal min) where T : class
		{
			return () => Verify.Args(holder).GreaterThan(min);
		}

		private static Action GreaterThanOrEqualAction<T>(T holder, decimal min) where T : class
		{
			return () => Verify.Args(holder).GreaterThanOrEqual(min);
		}

		private static Action LessThanAction<T>(T holder, decimal max) where T : class
		{
			return () => Verify.Args(holder).LessThan(max);
		}

		private static Action LessThanOrEqualAction<T>(T holder, decimal max) where T : class
		{
			return () => Verify.Args(holder).LessThanOrEqual(max);
		}

		private static Action InRangeAction<T>(T holder, decimal min, decimal max) where T : class
		{
			return () => Verify.Args(holder).InRange(min, max);
		}

		private static Action PositiveAction<T>(T holder) where T : class
		{
			return () => Verify.Args(holder).Positive();
		}

		private static Action NotNegativeAction<T>(T holder) where T : class
		{
			return () => Verify.Args(holder).NotNegative();
		}

		private static Action NegativeAction<T>(T holder) where T : class
		{
			return () => Verify.Args(holder).Negative();
		}

		private static Action NotPositiveAction<T>(T holder) where T : class
		{
			return () => Verify.Args(holder).NotPositive();
		}
	}
}
