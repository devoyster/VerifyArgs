using System;
using NUnit.Framework;
using SharpTestsEx;

namespace VerifyArgs.Test
{
	[TestFixture]
	public class LengthPluginsTest
	{
		[Test]
		public void LengthGreaterThan()
		{
			LengthGreaterThanAction(new { test = "" }, 1)
				.Should().Throw<ArgumentException>()
				.And.Exception.ParamName.Should().Be("test");
			LengthGreaterThanAction(new { test = "a" }, 1)
				.Should().Throw<ArgumentException>()
				.And.Exception.ParamName.Should().Be("test");
			LengthGreaterThanAction(new { test = "", test2 = new int[0] }, 1)
				.Should().Throw<ArgumentException>()
				.And.Exception.ParamName.Should().Be("test");
			LengthGreaterThanAction(new { test = "ab", test2 = new int[1] }, 1)
				.Should().Throw<ArgumentException>()
				.And.Exception.ParamName.Should().Be("test2");

			LengthGreaterThanAction((object)null, 1)();
			LengthGreaterThanAction(new { test = (string)null }, 1)();
			LengthGreaterThanAction(new { test = "ab" }, 1)();
			LengthGreaterThanAction(new { test = "ab", test2 = new int[3] }, 1)();
		}

		[Test]
		public void LengthGreaterThanOrEqual()
		{
			LengthGreaterThanOrEqualAction(new { test = "" }, 1)
				.Should().Throw<ArgumentException>()
				.And.Exception.ParamName.Should().Be("test");
			LengthGreaterThanOrEqualAction(new { test = "", test2 = new int[0] }, 1)
				.Should().Throw<ArgumentException>()
				.And.Exception.ParamName.Should().Be("test");
			LengthGreaterThanOrEqualAction(new { test = "ab", test2 = new int[0] }, 1)
				.Should().Throw<ArgumentException>()
				.And.Exception.ParamName.Should().Be("test2");

			LengthGreaterThanOrEqualAction((object)null, 1)();
			LengthGreaterThanOrEqualAction(new { test = (string)null }, 1)();
			LengthGreaterThanOrEqualAction(new { test = "a" }, 1)();
			LengthGreaterThanOrEqualAction(new { test = "a", test2 = new int[2] }, 1)();
		}

		[Test]
		public void LengthLessThan()
		{
			LengthLessThanAction(new { test = "ab" }, 1)
				.Should().Throw<ArgumentException>()
				.And.Exception.ParamName.Should().Be("test");
			LengthLessThanAction(new { test = "a" }, 1)
				.Should().Throw<ArgumentException>()
				.And.Exception.ParamName.Should().Be("test");
			LengthLessThanAction(new { test = "ab", test2 = new int[2] }, 1)
				.Should().Throw<ArgumentException>()
				.And.Exception.ParamName.Should().Be("test");
			LengthLessThanAction(new { test = "", test2 = new int[1] }, 1)
				.Should().Throw<ArgumentException>()
				.And.Exception.ParamName.Should().Be("test2");

			LengthLessThanAction((object)null, 1)();
			LengthLessThanAction(new { test = (string)null }, 1)();
			LengthLessThanAction(new { test = "" }, 1)();
			LengthLessThanAction(new { test = "", test2 = new int[0] }, 1)();
		}

		[Test]
		public void LengthLessThanOrEqual()
		{
			LengthLessThanOrEqualAction(new { test = "ab" }, 1)
				.Should().Throw<ArgumentException>()
				.And.Exception.ParamName.Should().Be("test");
			LengthLessThanOrEqualAction(new { test = "ab", test2 = new int[2] }, 1)
				.Should().Throw<ArgumentException>()
				.And.Exception.ParamName.Should().Be("test");
			LengthLessThanOrEqualAction(new { test = "", test2 = new int[2] }, 1)
				.Should().Throw<ArgumentException>()
				.And.Exception.ParamName.Should().Be("test2");

			LengthLessThanOrEqualAction((object)null, 1)();
			LengthLessThanOrEqualAction(new { test = (string)null }, 1)();
			LengthLessThanOrEqualAction(new { test = "a" }, 1)();
			LengthLessThanOrEqualAction(new { test = "a", test2 = new int[0] }, 1)();
		}

		[Test]
		public void LengthEquals()
		{
			LengthEqualsAction(new { test = "ab" }, 1)
				.Should().Throw<ArgumentException>()
				.And.Exception.ParamName.Should().Be("test");
			LengthEqualsAction(new { test = "", test2 = new int[2] }, 1)
				.Should().Throw<ArgumentException>()
				.And.Exception.ParamName.Should().Be("test");
			LengthEqualsAction(new { test = "a", test2 = new int[2] }, 1)
				.Should().Throw<ArgumentException>()
				.And.Exception.ParamName.Should().Be("test2");

			LengthEqualsAction((object)null, 1)();
			LengthEqualsAction(new { test = (string)null }, 1)();
			LengthEqualsAction(new { test = "a" }, 1)();
			LengthEqualsAction(new { test = "a", test2 = new int[1] }, 1)();
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

			LengthInRangeAction((object)null, 2, 4)();
			LengthInRangeAction(new { test = (string)null }, 2, 4)();
			LengthInRangeAction(new { test = "abc" }, 3, 3)();
			LengthInRangeAction(new { test = "ab" }, 2, 4)();
			LengthInRangeAction(new { test = "abc", test2 = new int[4] }, 2, 4)();
		}

		private Action LengthGreaterThanAction<T>(T holder, int min) where T : class
		{
			return Executing.This(() => Verify.Args(holder).LengthGreaterThan(min));
		}

		private Action LengthGreaterThanOrEqualAction<T>(T holder, int min) where T : class
		{
			return Executing.This(() => Verify.Args(holder).LengthGreaterThanOrEqual(min));
		}

		private Action LengthLessThanAction<T>(T holder, int max) where T : class
		{
			return Executing.This(() => Verify.Args(holder).LengthLessThan(max));
		}

		private Action LengthLessThanOrEqualAction<T>(T holder, int max) where T : class
		{
			return Executing.This(() => Verify.Args(holder).LengthLessThanOrEqual(max));
		}

		private Action LengthEqualsAction<T>(T holder, int len) where T : class
		{
			return Executing.This(() => Verify.Args(holder).LengthEquals(len));
		}

		private Action LengthInRangeAction<T>(T holder, int min, int max) where T : class
		{
			return Executing.This(() => Verify.Args(holder).LengthInRange(min, max));
		}
	}
}
