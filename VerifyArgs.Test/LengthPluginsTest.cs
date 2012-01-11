using System;
using NUnit.Framework;
using SharpTestsEx;

namespace VerifyArgs.Test
{
	[TestFixture]
	public class LengthPluginsTest
	{
		[Test]
		public void MinLength()
		{
			MinLengthAction(new { test = "" }, 1)
				.Should().Throw<ArgumentException>()
				.And.Exception.ParamName.Should().Be("test");
			MinLengthAction(new { test = "", test2 = new int[0] }, 1)
				.Should().Throw<ArgumentException>()
				.And.Exception.ParamName.Should().Be("test");
			MinLengthAction(new { test = "ab", test2 = new int[0] }, 1)
				.Should().Throw<ArgumentException>()
				.And.Exception.ParamName.Should().Be("test2");

			MinLengthAction(new { test = (string)null }, 1)();
			MinLengthAction(new { test = "a" }, 1)();
			MinLengthAction(new { test = "a", test2 = new int[2] }, 1)();
		}

		[Test]
		public void MaxLength()
		{
			MaxLengthAction(new { test = "ab" }, 1)
				.Should().Throw<ArgumentException>()
				.And.Exception.ParamName.Should().Be("test");
			MaxLengthAction(new { test = "ab", test2 = new int[2] }, 1)
				.Should().Throw<ArgumentException>()
				.And.Exception.ParamName.Should().Be("test");
			MaxLengthAction(new { test = "", test2 = new int[2] }, 1)
				.Should().Throw<ArgumentException>()
				.And.Exception.ParamName.Should().Be("test2");

			MaxLengthAction(new { test = (string)null }, 1)();
			MaxLengthAction(new { test = "a" }, 1)();
			MaxLengthAction(new { test = "a", test2 = new int[0] }, 1)();
		}

		[Test]
		public void LengthEqual()
		{
			LengthEqualAction(new { test = "ab" }, 1)
				.Should().Throw<ArgumentException>()
				.And.Exception.ParamName.Should().Be("test");
			LengthEqualAction(new { test = "", test2 = new int[2] }, 1)
				.Should().Throw<ArgumentException>()
				.And.Exception.ParamName.Should().Be("test");
			LengthEqualAction(new { test = "a", test2 = new int[2] }, 1)
				.Should().Throw<ArgumentException>()
				.And.Exception.ParamName.Should().Be("test2");

			LengthEqualAction(new { test = (string)null }, 1)();
			LengthEqualAction(new { test = "a" }, 1)();
			LengthEqualAction(new { test = "a", test2 = new int[1] }, 1)();
		}

		[Test]
		public void LengthInRange()
		{
			LengthInRangeAction(new { test = "ab" }, 4, 3)
				.Should().Throw<ArgumentException>()
				.And.Exception.ParamName.Should().Be("test");
			LengthInRangeAction(new { test = "ab" }, 3, 3)
				.Should().Throw<ArgumentException>()
				.And.Exception.ParamName.Should().Be("test");
			LengthInRangeAction(new { test = "a" }, 2, 4)
				.Should().Throw<ArgumentException>()
				.And.Exception.ParamName.Should().Be("test");
			LengthInRangeAction(new { test = "abcde" }, 2, 4)
				.Should().Throw<ArgumentException>()
				.And.Exception.ParamName.Should().Be("test");
			LengthInRangeAction(new { test = "a", test2 = new int[1] }, 2, 4)
				.Should().Throw<ArgumentException>()
				.And.Exception.ParamName.Should().Be("test");
			LengthInRangeAction(new { test = "abc", test2 = new int[5] }, 2, 4)
				.Should().Throw<ArgumentException>()
				.And.Exception.ParamName.Should().Be("test2");

			LengthInRangeAction(new { test = (string)null }, 2, 4)();
			LengthInRangeAction(new { test = "abc" }, 3, 3)();
			LengthInRangeAction(new { test = "ab" }, 2, 4)();
			LengthInRangeAction(new { test = "abc", test2 = new int[4] }, 2, 4)();
		}

		private static Action MinLengthAction<T>(T holder, int min) where T : class
		{
			return () => Verify.Args(holder).MinLength(min);
		}

		private static Action MaxLengthAction<T>(T holder, int max) where T : class
		{
			return () => Verify.Args(holder).MaxLength(max);
		}

		private static Action LengthEqualAction<T>(T holder, int len) where T : class
		{
			return () => Verify.Args(holder).LengthEqual(len);
		}

		private static Action LengthInRangeAction<T>(T holder, int min, int max) where T : class
		{
			return () => Verify.Args(holder).LengthInRange(min, max);
		}
	}
}
