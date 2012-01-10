using System;
using System.Linq;
using System.Reflection;
using NUnit.Framework;
using SharpTestsEx;
using VerifyArgs.Codegen;

namespace VerifyArgs.Test.Codegen
{
	[TestFixture]
	public class TypeUtilTest
	{
		private static readonly Func<Type, bool> IsAnonymousFunc =
			(Func<Type, bool>)Delegate.CreateDelegate(typeof(Func<Type, bool>), typeof(TypeUtil).GetMethod("IsAnonymous", BindingFlags.NonPublic | BindingFlags.Static));

		[Test]
		public void IsNumeric()
		{
			Executing.This(() => TypeUtil.IsNumeric(null)).Should().Throw<ArgumentNullException>();

			new[] { typeof(byte), typeof(short), typeof(ushort), typeof(int), typeof(uint), typeof(long), typeof(ulong), typeof(decimal), typeof(float), typeof(double) }
				.All(TypeUtil.IsNumeric)
				.Should().Be.True();
			new[] { typeof(object), typeof(string), typeof(DateTime), typeof(Guid) }
				.Any(TypeUtil.IsNumeric)
				.Should().Be.False();
		}

		[Test]
		public void HasProperty()
		{
			Executing.This(() => TypeUtil.HasProperty(null, "test")).Should().Throw<ArgumentNullException>();
			Executing.This(() => typeof(object).HasProperty(null)).Should().Throw<ArgumentNullException>();

			var type = new { x = 1, y = 2 }.GetType();
			type.HasProperty("x").Should().Be.True();
			type.HasProperty("y").Should().Be.True();
			type.HasProperty("z").Should().Be.False();
		}

		[Test]
		public void HasLengthProperty()
		{
			Executing.This(() => TypeUtil.HasLengthProperty(null)).Should().Throw<ArgumentNullException>();

			new { x = 1 }.GetType().HasLengthProperty().Should().Be.False();
			new { Length = 1 }.GetType().HasLengthProperty().Should().Be.True();
			new { Count = 1 }.GetType().HasLengthProperty().Should().Be.True();
			new { x = 1, Length = 1 }.GetType().HasLengthProperty().Should().Be.True();
			new { x = 1, Length = 1, Count = 1 }.GetType().HasLengthProperty().Should().Be.True();
		}

		[Test]
		public void IsAnonymous()
		{
			Executing.This(() => IsAnonymousFunc(null)).Should().Throw<ArgumentNullException>();

			IsAnonymousFunc(new { x = 1 }.GetType()).Should().Be.True();
			IsAnonymousFunc(new { s1 = "1", s2 = "2" }.GetType()).Should().Be.True();

			new[] { typeof(object), typeof(string), typeof(DateTime), typeof(Guid), typeof(byte), typeof(short), typeof(ushort), typeof(int), typeof(uint), typeof(long), typeof(ulong), typeof(decimal), typeof(float), typeof(double) }
				.Any(IsAnonymousFunc)
				.Should().Be.False();
		}
	}
}
